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

        #region �ⲿ�ӿ�

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="keyword">�ؼ���</param>
        /// <returns></returns>
        public List<Sto_StockIn> GetDataList(string condition, string keyword, Pagination pagination)
        {
            var q = GetIQueryable();

            //ģ����ѯ
            if (!condition.IsNullOrEmpty() && !keyword.IsNullOrEmpty())
                q = q.Where($@"{condition}.Contains(@0)", keyword);

            return q.GetPagination(pagination).ToList();
        }

        /// <summary>
        /// ��ȡָ���ĵ�������
        /// </summary>
        /// <param name="id">����</param>
        /// <returns></returns>
        public StockInModel GetTheData(string id)
        {
            StockInModel model = new StockInModel(GetEntity(id));
            model.StockInItems = this._StockInItemBusiness.GetDataList(model.InNo);
            return model;
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="newData">����</param>
        public void AddData(StockInModel newData)
        {
            if (newData.Id.IsNullOrEmpty())
            {
                newData.Id = Guid.NewGuid().ToSequentialGuid();
                //������ⵥ���
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

                        throw new Exception("��������ʧ��");
                    }
                }                    
            }
            else
            {
                UpdateData(newData);
            }            
        }

        /// <summary>
        /// ��������
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
                throw new Exception("Ҫ�޸ĵ���ⵥ�����ڣ������ѱ�ɾ��");
            }
            if (stockIn.State != 0)
            {
                throw new Exception("��¼��״̬�����޸�");
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
                    throw new Exception("�޸���ⵥʧ�ܡ�");
                }
            }
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public void DeleteData(List<string> ids)
        {
            var query = this.GetIQueryable().Where(p => ids.Contains(p.Id) && p.State != 0).ToList();
            if (query.Count() > 0)
            {
                throw new Exception("����˵���ⵥ���ܱ�ɾ��");
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
                    throw new Exception("ɾ����ⵥʧ��");
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
                throw new Exception("���ʧ�ܡ�");
            }
        }
        /// <summary>
        /// �����
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
                item.Context = $"����Ա��{operName}�������";
                this.Update(item);
            }
            if (!this.EndTransaction())
            {
                throw new Exception("�������ʧ�ܡ�");
            }
        }


        public void CancelStockIn(string id,string operName,string context)
        {
            var stockIn = this.GetEntity(id);
            if (stockIn == null)
            {
                throw new Exception("��ⵥ������");
            }
            if(stockIn.State == 1)
            {
                throw new Exception("�������⿴�������ϡ�");
            }
            if (stockIn.State == 2)
            {
                throw new Exception("�����ظ�������ⵥ��");
            }
            this.BeginTransaction();
            stockIn.State = 2;
            //stockIn.InOperID = operName;
            stockIn.AuditDate = DateTime.Now;
            stockIn.Context = $"�����ѱ���{operName}���ϣ�ԭ��{context}";
            if (!this.EndTransaction())
            {
                throw new Exception("����ʧ�ܡ�");
            }
        }

        #endregion

        #region ˽�г�Ա

        #endregion

        #region ����ģ��

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