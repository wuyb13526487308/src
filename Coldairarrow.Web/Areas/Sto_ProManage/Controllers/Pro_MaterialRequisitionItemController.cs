using Coldairarrow.Business.Sto_ProManage;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    public class Pro_MaterialRequisitionItemController : BaseMvcController
    {
        Pro_MaterialRequisitionItemBusiness _pro_MaterialRequisitionItemBusiness = new Pro_MaterialRequisitionItemBusiness();

        #region 视图功能

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            var theData = id.IsNullOrEmpty() ? new Pro_MaterialRequisitionItem() : _pro_MaterialRequisitionItemBusiness.GetTheData(id);

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
            var dataList = _pro_MaterialRequisitionItemBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="theData">保存的数据</param>
        public ActionResult SaveData(Pro_MaterialRequisitionItem theData)
        {
            if(theData.Id.IsNullOrEmpty())
            {
                theData.Id = Guid.NewGuid().ToSequentialGuid();

                _pro_MaterialRequisitionItemBusiness.AddData(theData);
            }
            else
            {
                _pro_MaterialRequisitionItemBusiness.UpdateData(theData);
            }

            return Success();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public ActionResult DeleteData(string ids)
        {
            _pro_MaterialRequisitionItemBusiness.DeleteData(ids.ToList<string>());

            return Success("删除成功！");
        }

        #endregion
    }
}