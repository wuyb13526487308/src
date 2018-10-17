using Coldairarrow.Business.Sto_BaseInfo;
using Coldairarrow.Business.Sto_ProManage;
using Coldairarrow.Entity.Sto_BaseInfo;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    public class Pro_TemplateItemController : BaseMvcController
    {
        Pro_TemplateItemBusiness _pro_TemplateItemBusiness = new Pro_TemplateItemBusiness();
        Sto_MaterialBusiness _sto_MaterialBusiness = new Sto_MaterialBusiness();
        static SystemCache _systemCache = new SystemCache();

        #region 视图功能

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            Pro_TemplateItem theData = null;
            if (id.Contains("cache_"))
            {
                string str = id.Replace("cache_", "");
                Sto_Material mat = _sto_MaterialBusiness.GetEntity(str);
                theData = new Pro_TemplateItem()
                {
                    MatName = mat.MatName,
                    MatNo = mat.MatNo,
                    UnitNo = mat.UnitNo,
                    GuiGe = mat.GuiGe,
                    Context = mat.Context
                };
            }
            else
            {
                theData = id.IsNullOrEmpty() ? new Pro_TemplateItem() { Id = Guid.NewGuid().ToSequentialGuid() } : _pro_TemplateItemBusiness.GetEntity(id);
                if (theData == null)
                {
                    theData = new Pro_TemplateItem()
                    {
                        Id = Guid.NewGuid().ToSequentialGuid()
                    };
                }
            }
            return View(theData);
        }

        public ActionResult FindCacheItem(string id)
        {
            id = "12345";
            var theData = _systemCache.GetCache<Pro_TemplateItem>(id);
            if (theData == null)
            {
                theData = new Pro_TemplateItem();
            }
            else
            {
                //清除缓存
                _systemCache.RemoveCache(id);
            }

            return Content(theData.ToJson());
        }

        #endregion

        #region 获取数据

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">查询类型</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public ActionResult GetDataList(string condition, string keyword, Pagination pagination)
        {
            var dataList = _pro_TemplateItemBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }



        #endregion

        #region 提交数据

        /// <summary>
        /// 创建缓存项目(用于创建工程料单模板时使用)
        /// </summary>
        /// <param name="theData"></param>
        /// <returns></returns>
        public ActionResult CreateCacheItem(Pro_TemplateItem theData)
        {
            theData.Id = "12345";
            if (theData.Id.IsNullOrEmpty())
            {
                return Error("新建项Id不为空");
            }
            else
            {
                _systemCache.SetCache(theData.Id, theData, new TimeSpan(0, 1, 0));
            }
            return Success();
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="theData">保存的数据</param>
        public ActionResult SaveData(Pro_TemplateItem theData)
        {
            if(theData.Id.IsNullOrEmpty())
            {
                theData.Id = Guid.NewGuid().ToSequentialGuid();

                _pro_TemplateItemBusiness.AddData(theData);
            }
            else
            {
                _pro_TemplateItemBusiness.UpdateData(theData);
            }

            return Success();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public ActionResult DeleteData(string ids)
        {
            _pro_TemplateItemBusiness.DeleteData(ids.ToList<string>());

            return Success("删除成功！");
        }

        #endregion
    }
}