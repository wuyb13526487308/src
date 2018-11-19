using Coldairarrow.Business.Sto_ProManage;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    public class Pro_MaterialRequisitionController : BaseMvcController
    {
        Pro_MaterialRequisitionBusiness _pro_MaterialRequisitionBusiness = new Pro_MaterialRequisitionBusiness();
        static SystemCache _systemCache = new SystemCache();

        #region 视图功能

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            var theData = id.IsNullOrEmpty() ? new MaterialRequisitionModel() : _pro_MaterialRequisitionBusiness.GetTheData(id);

            return View(theData);
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
            var dataList = _pro_MaterialRequisitionBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 保存数据修改
        /// </summary>
        /// <param name="theData">保存的数据</param>
        public ActionResult SaveData(MaterialRequisitionModel theData)
        {
            //if(theData.Id.IsNullOrEmpty())
            //{
            //    theData.Id = Guid.NewGuid().ToSequentialGuid();

            //    _pro_MaterialRequisitionBusiness.AddData(theData);
            //}
            //else
            //{
            //    _pro_MaterialRequisitionBusiness.UpdateData(theData);
            //}

            return Success();
        }

        /// <summary>
        /// 删除领料单
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public ActionResult DeleteData(string ids)
        {

            string result = _pro_MaterialRequisitionBusiness.DeleteData(ids.ToList<string>());
            if (result == "")
            {
                return Success("删除成功！");
            }
            else
            {
                return Error(result);
            }
        }

        public ActionResult RemoveRowToCached(string mrId,string itemId)
        {
            //读取缓存的数据
            List<string> ids = _systemCache.GetCache(mrId) as List<String>;
            if (ids == null)
            {
                ids = new List<string>();
            }
            ids.Add(itemId);
            _systemCache.SetCache(mrId, ids, new TimeSpan(1, 1, 0));
            return Success("成功！");
        }

        public ActionResult ClearCached(string mrId)
        {
            _systemCache.RemoveCache(mrId);
            return Success();
        }

        #endregion
    }
}