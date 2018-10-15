using Coldairarrow.Entity.Sto_BaseInfo;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Coldairarrow.Business.Sto_BaseInfo
{
    public class Sto_MaterialBusiness : BaseBusiness<Sto_Material>
    {
        #region �ⲿ�ӿ�

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="keyword">�ؼ���</param>
        /// <returns></returns>
        public List<Sto_Material> GetDataList(string condition, string keyword, Pagination pagination)
        {
            //var whereExpre = LinqHelper.True<Sto_MaterialModel>();
            //Expression<Func<Sto_Material, object, object, object, object, Sto_MaterialModel>> selectExpre = (a, b, c, d, e) => new Sto_MaterialModel
            //{
            //    ClassNameList = (List<string>)b,
            //    ClassIdList = (List<string>)c,
            //    MaterialUnitIdList = (List<string>)d,
            //    MaterialUnitNameList = (List<string>)e
            //};
            //selectExpre = selectExpre.BuildExtendSelectExpre();
            
            //var db_Sto_BigClass = Service.GetIQueryable<Sto_BigClass>();
            //var db_Sto_MaterialUnit = Service.GetIQueryable<Sto_MaterialUnit>();
            //var q = from a in GetIQueryable().AsExpandable()
            //        let classIds = db_Sto_BigClass.Where

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
        public Sto_Material GetTheData(string id)
        {
            return GetEntity(id);
        }

        //public static List<string> GetUserDepartIds(string userId)
        //{
        //    return GetTheUser(userId).DepartmentIdList;
        //}


        /// <summary>
        /// �������
        /// </summary>
        /// <param name="newData">����</param>
        public void AddData(Sto_Material newData)
        {
            Insert(newData);
        }

        /// <summary>
        /// ��������
        /// </summary>
        public void UpdateData(Sto_Material theData)
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

    public class Sto_MaterialModel : Sto_Material
    {
        public List<string> ClassIdList { get; set; }

        public List<string> ClassNameList { get; set; }

        public List<string> MaterialUnitIdList { get; set; }

        public List<string> MaterialUnitNameList { get; set; }



    }
}