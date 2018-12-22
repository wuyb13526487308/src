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

        #region ��ͼ����

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

        #region ��ȡ����

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="param">��ѯ����:json�ַ�����ʽ��{StoreId:value1,BigClass:value2,GuiGe:value3,UnitNo:value4,MatNo:value5}</param>
        /// <returns></returns>
        public ActionResult GetDataList(string param,  Pagination pagination)
        {
            new SystemCache().SetCache("stock_query", param==null?"":param,new TimeSpan(3,0,0));
            var dataList = _sto_StockBusiness.GetDataList(param, pagination);
            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        /// <summary>
        /// ���ص�ǰ��ѯ�Ŀ���б�
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public ActionResult DownLoad(string key)
        {
            string param = $"{new SystemCache().GetCache("stock_query")}";
            var dataList = _sto_StockBusiness.GetDataList(param, new Pagination() { PageRows=int.MaxValue});
            string outputFileName = $"���-{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("�ֿ�"));
            dataTable.Columns.Add(new DataColumn("����"));
            dataTable.Columns.Add(new DataColumn("����"));
            dataTable.Columns.Add(new DataColumn("����"));
            dataTable.Columns.Add(new DataColumn("���"));
            dataTable.Columns.Add(new DataColumn("��λ"));
            dataTable.Columns.Add(new DataColumn("����"));
            dataTable.Columns.Add(new DataColumn("����"));
            dataTable.Columns.Add(new DataColumn("����"));
            dataTable.Columns.Add(new DataColumn("����"));
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

        #region �ύ����

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="theData">���������</param>
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
        /// ɾ������
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public ActionResult DeleteData(string ids)
        {
            _sto_StockBusiness.DeleteData(ids.ToList<string>());

            return Success("ɾ���ɹ���");
        }

        #endregion
    }
}