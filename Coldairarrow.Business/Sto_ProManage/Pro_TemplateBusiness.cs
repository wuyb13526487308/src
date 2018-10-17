using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;

namespace Coldairarrow.Business.Sto_ProManage
{
    public class Pro_TemplateBusiness : BaseBusiness<Pro_Template>
    {
        static Pro_TemplateModelCache _cache { get; } = new Pro_TemplateModelCache();

        #region 外部接口

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">查询类型</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public List<Pro_TemplateModel> GetDataList(string condition, string keyword, Pagination pagination)
        {
            var whereExpre = LinqHelper.True<Pro_TemplateModel>();
            Expression<Func<Pro_Template, object, Pro_TemplateModel>> selectExpre = (a, b) => new Pro_TemplateModel
            {
                TemplateItemList = (List<Pro_TemplateItem>)b,
            };
            selectExpre = selectExpre.BuildExtendSelectExpre();
            var db_Sto_TemplateItem = Service.GetIQueryable<Pro_TemplateItem>();

            //var db_Sto_MaterialUnit = Service.GetIQueryable<Sto_MaterialUnit>();
            var q = from a in GetIQueryable().AsExpandable()
                    let templateItems = db_Sto_TemplateItem.Where(x => x.TemplateId == a.TemplateId).ToList()
                    select selectExpre.Invoke(a, templateItems);


            //var q = GetIQueryable();

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
        public Pro_TemplateModel GetTheData(string id)
        {
            return _cache.GetCache(id);
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="newData">数据</param>
        public void AddData(Pro_Template newData)
        {
            Insert(newData);
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        public void UpdateData(Pro_Template theData)
        {
            Update(theData);
            _cache.UpdateCache(theData.TemplateId);
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

    public class Pro_TemplateModel : Pro_Template
    {

        public List<Pro_TemplateItem> TemplateItemList { get; set; } = new List<Pro_TemplateItem>();
    } 
}