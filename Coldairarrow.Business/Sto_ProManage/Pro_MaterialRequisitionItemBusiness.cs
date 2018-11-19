using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace Coldairarrow.Business.Sto_ProManage
{
    public class Pro_MaterialRequisitionItemBusiness : BaseBusiness<Pro_MaterialRequisitionItem>
    {
        #region �ⲿ�ӿ�

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="keyword">�ؼ���</param>
        /// <returns></returns>
        public List<Pro_MaterialRequisitionItem> GetDataList(string condition, string keyword, Pagination pagination)
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
        public Pro_MaterialRequisitionItem GetTheData(string id)
        {
            return GetEntity(id);
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="newData">����</param>
        public void AddData(Pro_MaterialRequisitionItem newData)
        {
            Insert(newData);
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void UpdateData(Pro_MaterialRequisitionItem theData)
        {
            Update(theData);
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public void DeleteData(List<string> ids)
        {
            Delete(ids);
        }

        #endregion

        public List<Pro_MaterialRequisitionItem> GetDataList(string mrId)
        {
            var q = GetIQueryable();
            return q.Where(p => p.MR_Id == mrId).ToList();
        }


        #region ˽�г�Ա

        #endregion

        #region ����ģ��

        #endregion
    }
}