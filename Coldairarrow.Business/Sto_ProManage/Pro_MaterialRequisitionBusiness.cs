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
        #region �ⲿ�ӿ�

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="keyword">�ؼ���</param>
        /// <returns></returns>
        public List<Pro_MaterialRequisition> GetDataList(string condition, string keyword, Pagination pagination)
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
        ///// �������
        ///// </summary>
        ///// <param name="newData">����</param>
        //public void AddData(Pro_MaterialRequisition newData)
        //{
        //    Insert(newData);
        //}

        /// <summary>
        /// �޸����뵥����
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
                return "�޸�����ʧ��";
            }
            if (mrItemBus.EndTransaction())
            {
                return "";
            }
            else
            {
                return "�޸�����ʧ��";
            }
        }

        /// <summary>
        /// ɾ���������쵥
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public string DeleteData(List<string> ids)
        {
            if (ids == null || ids.Count == 0)
                return "ɾ�����뵥id����Ϊ��";
            string id = ids[0];
            var query = GetIQueryable().Where(p => p.Id == id).ToList() ;
            if (query.Count == 0)
                return "ָ���ı�������";

            if (query[0].Status.Value != 0)
            {
                return "�����ϲ���ɾ��";
            }

            try
            {
                string delSql = $"delete from Pro_MaterialRequisitionItem where MR_Id ='{query[0].Id}';delete from Pro_MaterialRequisition where Id ='{query[0].Id}'";
                this.ExecuteSql(delSql);
            }
            catch
            {
                return "ִ��ɾ��ʧ��";
            }
            return "";
        }

        #endregion

        #region ˽�г�Ա

        #endregion

        #region ����ģ��

        #endregion
    }

    public class MaterialRequisitionModel : Pro_MaterialRequisition{

        public List<Pro_MaterialRequisitionItem> MReqItemList { get; set; } = new List<Pro_MaterialRequisitionItem>();
    }
}