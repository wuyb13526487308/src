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
        #region 外部接口

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">查询类型</param>
        /// <param name="keyword">关键字</param>
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
        public Sto_Material GetTheData(string id)
        {
            return GetEntity(id);
        }

        //public static List<string> GetUserDepartIds(string userId)
        //{
        //    return GetTheUser(userId).DepartmentIdList;
        //}


        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="newData">数据</param>
        public void AddData(Sto_Material newData)
        {
            Insert(newData);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public void UpdateData(Sto_Material theData)
        {
            Update(theData);
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public void DeleteData(List<string> ids)
        {
            Delete(ids);
        }

        #endregion

        #region 私有成员

        #endregion

        #region 数据模型

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