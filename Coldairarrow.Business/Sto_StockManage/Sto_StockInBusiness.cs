using Coldairarrow.Entity.Sto_StockManage;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace Coldairarrow.Business.Sto_StockManage
{
    public class Sto_StockInBusiness : BaseBusiness<Sto_StockIn>
    {
        Sto_StockInItemBusiness _StockInItemBusiness = new Sto_StockInItemBusiness();

        #region 外部接口

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">查询类型</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public List<Sto_StockIn> GetDataList(string condition, string keyword, Pagination pagination)
        {
            var q = GetIQueryable();

            //模糊查询
            if (!condition.IsNullOrEmpty() && !keyword.IsNullOrEmpty())
                q = q.Where($@"{condition}.Contains(@0)", keyword);

            return q.GetPagination(pagination).ToList();
        }

        /// <summary>
        /// 获取指定的单条数据
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public StockInModel GetTheData(string id)
        {
            StockInModel model = new StockInModel(GetEntity(id));
            model.StockInItems = this._StockInItemBusiness.GetDataList(model.InNo);
            return model;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="newData">数据</param>
        public void AddData(StockInModel newData)
        {
            if (newData.Id.IsNullOrEmpty())
            {
                newData.Id = Guid.NewGuid().ToSequentialGuid();
                //生成入库单编号
                this.BeginTransaction();
                this._StockInItemBusiness.BeginTransaction();

                foreach (Sto_StockInItem item in newData.StockInItems)
                {
                    item.Id = Guid.NewGuid().ToSequentialGuid();
                    item.InNo = newData.InNo;
                   
                }
                this._StockInItemBusiness.BulkInsert(newData.StockInItems);
                Sto_StockIn stockIn = new Sto_StockIn()
                {
                    Id = newData.Id,
                    InNo = newData.InNo,
                    InDate = newData.InDate,
                    InOperID = newData.InOperID,
                    State = newData.State,
                    StoreId = newData.StoreId,
                    AuditDate = newData.AuditDate,
                    Auditor = newData.Auditor,
                    Context = newData.Context 
                };

                Insert(stockIn);
                if (this._StockInItemBusiness.EndTransaction())
                {
                    if (!this.EndTransaction())
                    {
                        foreach (Sto_StockInItem item in newData.StockInItems)
                            this._StockInItemBusiness.Delete(item);

                        throw new Exception("保存数据失败");
                    }
                }                    
            }
            else
            {
                UpdateData(newData);
            }            
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public void UpdateData(StockInModel theData)
        {
            var oldStockInItems = this._StockInItemBusiness.GetIQueryable().Where(p => p.InNo == theData.InNo).ToList();
            var itemIds = (from p in oldStockInItems select p.Id).ToList<string>();
            List<string> thisItemIds = new List<string>();
            var stockIn = this.GetEntity(theData.Id);
            var copyIn = stockIn.DeepClone();
            if (stockIn == null)
            {
                throw new Exception("要修改的入库单不存在，可能已被删除");
            }
            if (stockIn.State != 0)
            {
                throw new Exception("非录入状态不能修改");
            }

            this.BeginTransaction();
            this._StockInItemBusiness.BeginTransaction();

            foreach(Sto_StockInItem item in theData.StockInItems)
            {
                if (item.Id.IsNullOrEmpty())
                {
                    item.Id = Guid.NewGuid().ToSequentialGuid();
                    item.InNo = theData.InNo;
                    this._StockInItemBusiness.Insert(item);
                }
                else
                {
                    thisItemIds.Add(item.Id);
                    item.InNo = theData.InNo;
                    this._StockInItemBusiness.Update(item);
                }
            }
            var exceptList = itemIds.Except(thisItemIds).ToList();
            this._StockInItemBusiness.Delete(exceptList);
            stockIn.InNo = theData.InNo;
            stockIn.InDate = theData.InDate;
            stockIn.InOperID = theData.InOperID;
            stockIn.State = theData.State;
            stockIn.StoreId = theData.StoreId;
            stockIn.AuditDate = theData.AuditDate;
            stockIn.Auditor = theData.Auditor;
            stockIn.Context = theData.Context;

            Update(stockIn);
            if (this.EndTransaction())
            {
                if (!this._StockInItemBusiness.EndTransaction())
                {
                    stockIn.InNo = copyIn.InNo;
                    stockIn.InDate = copyIn.InDate;
                    stockIn.InOperID = copyIn.InOperID;
                    stockIn.State = copyIn.State;
                    stockIn.StoreId = copyIn.StoreId;
                    stockIn.AuditDate = copyIn.AuditDate;
                    stockIn.Auditor = copyIn.Auditor;
                    stockIn.Context = copyIn.Context;
                    this.Update(stockIn);
                    throw new Exception("修改入库单失败。");
                }
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public void DeleteData(List<string> ids)
        {
            var query = this.GetIQueryable().Where(p => ids.Contains(p.Id) && p.State != 0).ToList();
            if (query.Count() > 0)
            {
                throw new Exception("已审核的入库单不能被删除");
            }
            var stockInList = this.GetIQueryable().Where(p => ids.Contains(p.Id)).ToList();
            this.BeginTransaction();
            _StockInItemBusiness.BeginTransaction();
            foreach (Sto_StockIn stockIn in stockInList)
            {
                this._StockInItemBusiness.Delete(p => p.InNo == stockIn.InNo);
                this.Delete(stockIn);
            }
            
            if(this.EndTransaction())
            {
                if(!this._StockInItemBusiness.EndTransaction())
                {
                    this.BulkInsert(stockInList);
                    throw new Exception("删除入库单失败");
                }
            }
        }

        public void AuditorStockIn(List<string> ids,string operName)
        {
            var query = this.GetIQueryable().Where(p => ids.Contains(p.Id) && p.State ==0).ToList();
            this.BeginTransaction();
            foreach (Sto_StockIn item in query)
            {
                item.State = 1;
                item.AuditDate = DateTime.Now;
                item.Auditor = operName;
                this.Update(item);
            }
            if (!this.EndTransaction())
            {
                throw new Exception("审核失败。");
            }
        }
        /// <summary>
        /// 反审核
        /// </summary>
        /// <param name="id"></param>
        /// <param name="operName"></param>
        public void UnAuditorStockIn(List<string> ids, string operName)
        {
            var query = this.GetIQueryable().Where(p => ids.Contains(p.Id) && p.State == 1).ToList();
            this.BeginTransaction();
            foreach (Sto_StockIn item in query)
            {
                item.State = 0;
                item.AuditDate = DateTime.Now;
                item.Auditor = operName;
                item.Context = $"操作员：{operName}撤销审核";
                this.Update(item);
            }
            if (!this.EndTransaction())
            {
                throw new Exception("撤销审核失败。");
            }
        }


        public void CancelStockIn(string id,string operName,string context)
        {
            var stockIn = this.GetEntity(id);
            if (stockIn == null)
            {
                throw new Exception("入库单不存在");
            }
            if(stockIn.State == 1)
            {
                throw new Exception("已审核入库看不能作废。");
            }
            if (stockIn.State == 2)
            {
                throw new Exception("不能重复作废入库单。");
            }
            this.BeginTransaction();
            stockIn.State = 2;
            //stockIn.InOperID = operName;
            stockIn.AuditDate = DateTime.Now;
            stockIn.Context = $"订单已被：{operName}作废，原因：{context}";
            if (!this.EndTransaction())
            {
                throw new Exception("作废失败。");
            }
        }

        #endregion

        #region 私有成员

        #endregion

        #region 数据模型

        #endregion
    }

    public class StockInModel : Sto_StockIn
    {

        public List<Sto_StockInItem> StockInItems { get; set; } = new List<Sto_StockInItem>();


        public StockInModel()
        {
        }

        public StockInModel(Sto_StockIn stockIn)
        {
            this.Id = stockIn.Id;
            this.InDate = stockIn.InDate;
            this.InNo = stockIn.InNo;
            this.State = stockIn.State;
            this.StoreId = stockIn.StoreId;
            this.AuditDate = stockIn.AuditDate;
            this.Auditor = stockIn.Auditor;
            this.Context = stockIn.Context;
            this.InOperID = stockIn.InOperID; 
        }
    }
}