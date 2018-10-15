using Coldairarrow.Entity.Sto_BaseInfo;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace Coldairarrow.Business.Sto_BaseInfo
{
    public class Sto_MaterialUnitBusiness : BaseBusiness<Sto_MaterialUnit>
    {
        #region �ⲿ�ӿ�

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="keyword">�ؼ���</param>
        /// <returns></returns>
        public List<Sto_MaterialUnit> GetDataList(string condition, string keyword, Pagination pagination)
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
        public Sto_MaterialUnit GetTheData(string id)
        {
            return GetEntity(id);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="newData">����</param>
        public void AddData(Sto_MaterialUnit newData)
        {
            Insert(newData);
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void UpdateData(Sto_MaterialUnit theData)
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

        #region ˽�г�Ա

        #endregion

        #region ����ģ��

        #endregion
    }
}