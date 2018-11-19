using Coldairarrow.Business.Sto_ProManage;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    public class Pro_ProjectController : BaseMvcController
    {
        Pro_ProjectBusiness _pro_ProjectBusiness = new Pro_ProjectBusiness();

        #region 视图功能

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            var theData = id.IsNullOrEmpty() ? new Pro_Project() : _pro_ProjectBusiness.GetTheData(id);

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
            var dataList = _pro_ProjectBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        public ActionResult GetNormalProjectList()
        {
            var dataList = _pro_ProjectBusiness.GetAllDataList();
            //var q = from p in dataList where
            return Content(dataList.ToJson());
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="theData">保存的数据</param>
        public ActionResult SaveData(Pro_Project theData)
        {
            if(theData.Id.IsNullOrEmpty())
            {
                theData.Id = Guid.NewGuid().ToSequentialGuid();
                theData.CreateDate = DateTime.Now;
                theData.Status = "0";
                _pro_ProjectBusiness.AddData(theData);
            }
            else
            {
                _pro_ProjectBusiness.UpdateData(theData);
            }

            return Success();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public ActionResult DeleteData(string ids)
        {
            _pro_ProjectBusiness.DeleteData(ids.ToList<string>());

            return Success("删除成功！");
        }

        #endregion
    }
}