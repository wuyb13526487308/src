using Coldairarrow.Business.Sto_StockManage;
using Coldairarrow.Entity.Sto_StockManage;
using Coldairarrow.Util;
using System;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    public class Sto_StockController : BaseMvcController
    {
        Sto_StockBusiness _sto_StockBusiness = new Sto_StockBusiness();

        #region 视图功能

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            var theData = id.IsNullOrEmpty() ? new Sto_Stock() : _sto_StockBusiness.GetTheData(id);

            return View(theData);
        }

        #endregion

        #region 获取数据

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="param">查询参数:json字符串格式：{StoreId:value1,BigClass:value2,GuiGe:value3,UnitNo:value4,MatNo:value5}</param>
        /// <returns></returns>
        public ActionResult GetDataList(string param,  Pagination pagination)
        {
            var dataList = _sto_StockBusiness.GetDataList(param, pagination);
            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="theData">保存的数据</param>
        public ActionResult SaveData(Sto_Stock theData)
        {
            if(theData.Id.IsNullOrEmpty())
            {
                theData.Id = Guid.NewGuid().ToSequentialGuid();

                _sto_StockBusiness.AddData(theData);
            }
            else
            {
                _sto_StockBusiness.UpdateData(theData);
            }

            return Success();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public ActionResult DeleteData(string ids)
        {
            _sto_StockBusiness.DeleteData(ids.ToList<string>());

            return Success("删除成功！");
        }

        #endregion
    }
}