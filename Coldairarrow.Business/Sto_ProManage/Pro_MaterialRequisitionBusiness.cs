using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace Coldairarrow.Business.Sto_ProManage
{
    public class Pro_MaterialRequisitionBusiness : BaseBusiness<Pro_MaterialRequisition>
    {
        #region 外部接口

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">查询类型</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public List<Pro_MaterialRequisition> GetDataList(string condition, string keyword, Pagination pagination)
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
        public MaterialRequisitionModel GetTheData(string id)
        {
            Pro_MaterialRequisition mrData = GetEntity(id);
            MaterialRequisitionModel mrd = new MaterialRequisitionModel() {
                Id = mrData.Id,
                CreateDate = mrData.CreateDate,
                Creator = mrData.Creator,
                Picker = mrData.Picker,
                PMR_No = mrData.PMR_No,
                ProCode = mrData.ProCode,
                ProName = mrData.ProName,
                Status = mrData.Status
            };
            Pro_MaterialRequisitionItemBusiness mrb = new Pro_MaterialRequisitionItemBusiness();
            mrd.MReqItemList = mrb.GetDataList(id);
            return mrd;
        }

        ///// <summary>
        ///// 添加数据
        ///// </summary>
        ///// <param name="newData">数据</param>
        //public void AddData(Pro_MaterialRequisition newData)
        //{
        //    Insert(newData);
        //}

        /// <summary>
        /// 修改申请单数据
        /// </summary>
        /// 
        public string UpdateData(MaterialRequisitionModel theData,List<string> itemList)
        {
            Pro_MaterialRequisitionItemBusiness mrItemBus = new Pro_MaterialRequisitionItemBusiness();
            try
            {
                mrItemBus.BeginTransaction();
                if (itemList != null && itemList.Count > 0)
                {
                    mrItemBus.Delete(itemList);
                }
                theData.MReqItemList.ForEach(item =>
                {
                    mrItemBus.UpdateWhere(x => x.Id == item.Id, x =>
                    {
                        x.Quantity = item.Quantity;
                    });
                });
            }
            catch
            {
                return "修改数据失败";
            }
            if (mrItemBus.EndTransaction())
            {
                return "";
            }
            else
            {
                return "修改数据失败";
            }
        }

        /// <summary>
        /// 删除物料申领单
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public string DeleteData(List<string> ids)
        {
            if (ids == null || ids.Count == 0)
                return "删除申请单id不能为空";
            string id = ids[0];
            var query = GetIQueryable().Where(p => p.Id == id).ToList() ;
            if (query.Count == 0)
                return "指定的表单不存在";

            if (query[0].Status.Value != 0)
            {
                return "已领料不能删除";
            }

            try
            {
                string delSql = $"delete from Pro_MaterialRequisitionItem where MR_Id ='{query[0].Id}';delete from Pro_MaterialRequisition where Id ='{query[0].Id}'";
                this.ExecuteSql(delSql);
            }
            catch
            {
                return "执行删除失败";
            }
            return "";
        }

        #endregion

        #region 私有成员

        #endregion

        #region 数据模型

        #endregion
    }

    public class MaterialRequisitionModel : Pro_MaterialRequisition{

        public List<Pro_MaterialRequisitionItem> MReqItemList { get; set; } = new List<Pro_MaterialRequisitionItem>();
    }
}