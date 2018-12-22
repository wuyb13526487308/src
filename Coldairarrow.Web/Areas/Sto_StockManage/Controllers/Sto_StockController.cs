using Aspose.Cells;
using Coldairarrow.Business.Sto_StockManage;
using Coldairarrow.Entity.Sto_StockManage;
using Coldairarrow.Util;
using Coldairarrow.Util.lib;
using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
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
            new SystemCache().SetCache("stock_query", param==null?"":param,new TimeSpan(3,0,0));
            var dataList = _sto_StockBusiness.GetDataList(param, pagination);
            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        /// <summary>
        /// 下载当前查询的库存列表
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ActionResult DownLoad(string key)
        {
            string param = $"{new SystemCache().GetCache("stock_query")}";
            var dataList = _sto_StockBusiness.GetDataList(param, new Pagination() { PageRows=int.MaxValue});
            string outputFileName = $"库存-{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("仓库"));
            dataTable.Columns.Add(new DataColumn("编码"));
            dataTable.Columns.Add(new DataColumn("名称"));
            dataTable.Columns.Add(new DataColumn("分类"));
            dataTable.Columns.Add(new DataColumn("规格"));
            dataTable.Columns.Add(new DataColumn("单位"));
            dataTable.Columns.Add(new DataColumn("数量"));
            dataTable.Columns.Add(new DataColumn("单价"));
            dataTable.Columns.Add(new DataColumn("上限"));
            dataTable.Columns.Add(new DataColumn("下限"));
            foreach(Sto_StockBusiness.Stock stock in dataList)
            {
                DataRow newRow = dataTable.NewRow();
                newRow[0] = stock.StoreName;
                newRow[1] = stock.MatNo;
                newRow[2] = stock.MatName;
                newRow[3] = stock.BigClassName;
                newRow[4] = stock.GuiGe;
                newRow[5] = stock.UnitName;
                newRow[6] = stock.Quantity;
                newRow[7] = stock.Price;
                newRow[8] = stock.MaxStoreQuantity;
                newRow[9] = stock.WarnStoreQuantity;
                dataTable.Rows.Add(newRow);
            }
           
            OperateExcel.ExportToExcel(System.Web.HttpContext.Current, dataTable, outputFileName);
            return new EmptyResult();
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