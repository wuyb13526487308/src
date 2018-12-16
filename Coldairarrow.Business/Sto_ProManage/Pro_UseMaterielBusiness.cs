using Coldairarrow.Entity.Sto_BaseInfo;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Coldairarrow.Business.Sto_ProManage
{
    public class Pro_UseMaterielBusiness : BaseBusiness<Pro_UseMateriel>
    {
        #region 外部接口

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">查询类型</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public List<UseMaterielModel> GetDataList(string condition, string keyword, Pagination pagination)
        {
            //var q = GetIQueryable();
            var whereExpre = LinqHelper.True<UseMaterielModel>();

            Expression<Func<Pro_UseMateriel, object, UseMaterielModel>> selectExpre = (a, b) => new UseMaterielModel
            {
                UnitNameList = (List<string>)b
            };
            selectExpre = selectExpre.BuildExtendSelectExpre();

            var db_MaterialUnitMap = Service.GetIQueryable<Sto_MaterialUnit>();

            var q = from a in GetIQueryable().AsExpandable()
                    let UnitNames = db_MaterialUnitMap.Where(x => x.UnitNum == a.UnitNo).Select(x => x.Name)
                    select selectExpre.Invoke(a, UnitNames);

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
        public Pro_UseMateriel GetTheData(string id)
        {
            return GetEntity(id);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="newData">数据</param>
        public void AddData(Pro_UseMateriel newData)
        {
            Insert(newData);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public void UpdateData(Pro_UseMateriel theData)
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

    public class UseMaterielModel : Pro_UseMateriel
    {
        public List<string> UnitNameList { get; set; }

    }
}