using Coldairarrow.Business.Sto_ProManage;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    public class Pro_UseMaterielController : BaseMvcController
    {
        Pro_UseMaterielBusiness _pro_UseMaterielBusiness = new Pro_UseMaterielBusiness();

        #region 视图功能

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            var theData = id.IsNullOrEmpty() ? new Pro_UseMateriel() : _pro_UseMaterielBusiness.GetTheData(id);

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
            var dataList = _pro_UseMaterielBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="theData">保存的数据</param>
        public ActionResult SaveData(Pro_UseMateriel theData)
        {
            //检查是否领料，输入的数量是否足够

            if(theData.Id.IsNullOrEmpty())
            {
                theData.Id = Guid.NewGuid().ToSequentialGuid();
                theData.RegDate = DateTime.Now;
                _pro_UseMaterielBusiness.AddData(theData);
            }
            else
            {
                _pro_UseMaterielBusiness.UpdateData(theData);
            }

            return Success();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public ActionResult DeleteData(string ids)
        {
            _pro_UseMaterielBusiness.DeleteData(ids.ToList<string>());

            return Success("删除成功！");
        }

        #endregion
    }
}