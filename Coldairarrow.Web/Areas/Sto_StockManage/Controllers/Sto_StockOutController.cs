using Coldairarrow.Business.Base_SysManage;
using Coldairarrow.Business.Sto_ProManage;
using Coldairarrow.Business.Sto_StockManage;
using Coldairarrow.Entity.Sto_BaseInfo;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Entity.Sto_StockManage;
using Coldairarrow.Util;
using Coldairarrow.Util.lib;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    public class Sto_StockOutController : BaseMvcController
    {
        Sto_StockOutBusiness _sto_StockOutBusiness = new Sto_StockOutBusiness();

        #region ��ͼ����

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Find()
        {
            return View();
        }
        /// <summary>
        /// ��ͨ����
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult FormNormal(string id)
        {
            var theData = id.IsNullOrEmpty() ? new StockOutModel()
                    { OutOperID = Base_UserBusiness.GetCurrentUser().RealName } : _sto_StockOutBusiness.GetStockOut(id);

            return View(theData);
        }

        public ActionResult FormShow(string id)
        {
            var theData = id.IsNullOrEmpty() ? new StockOutModel() : _sto_StockOutBusiness.GetStockOut(id);
            return View(theData);
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <returns></returns>
        public ActionResult FormPro()
        {
            MaterialRequisitionModel mrm = new MaterialRequisitionModel();

            return View(mrm);
        }

        public ActionResult StockOutList()
        {

            return View();
        }

        #endregion
        static SystemCache _systemCache = new SystemCache();

        public ActionResult FindCacheItem(string id)
        {
            var theData = _systemCache.GetCache<List<Sto_Material>>(id);
            if (theData == null)
            {
                theData = new List<Sto_Material>();
            }
            else
            {
                //�������
                _systemCache.RemoveCache(id);
            }

            return Content(theData.ToJson());
        }


        public ActionResult CreateCacheItem(CatchModel theData)
        {
            if (theData.Id.IsNullOrEmpty())
            {
                return Error("������Ч");
            }
            else
            {
                _systemCache.SetCache(theData.Id, theData.Entity, new TimeSpan(0, 1, 0));
            }
            return Success();
        }

        #region ��ȡ����

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="keyword">�ؼ���</param>
        /// <returns></returns>
        public ActionResult GetDataList(string condition, string keyword, Pagination pagination)
        {

            var dataList = _sto_StockOutBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        public ActionResult GetStockOutList(string StoreId, string OutNo,string B_OutDate,string E_OutDate, Pagination pagination)
        {
            
            new SystemCache().SetCache("stockout_query", new { StoreId, OutNo, B_OutDate, E_OutDate }, new TimeSpan(3, 0, 0));

            var dataList = _sto_StockOutBusiness.GetStockOutList(StoreId, OutNo, B_OutDate, E_OutDate, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        #endregion

        #region �ύ����

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="theData">���������</param>
        public ActionResult SaveOutData(StockOutModel theData)
        {
            if(theData.Id.IsNullOrEmpty())
            {
                theData.OutOperID = Base_UserBusiness.GetCurrentUser().UserId;
                _sto_StockOutBusiness.NormalMaterial(theData);
            }
            else
            {
                _sto_StockOutBusiness.NormalMaterial(theData);
            }

            return Success();
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public ActionResult DeleteData(string ids)
        {
            _sto_StockOutBusiness.DeleteData(ids.ToList<string>());

            return Success("ɾ���ɹ���");
        }



        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="theData"></param>
        /// <returns></returns>
        public ActionResult ProMaterial(ProMRModel theData)
        {
            StockOutModel stockOut = new StockOutModel();
            stockOut.Id = Guid.NewGuid().ToSequentialGuid();
            stockOut.ApplyNo = theData.MaterialRequisitionModel.PMR_No;//���ϵ����
            stockOut.StoreId = theData.StoreId;//Ĭ�ϲֿ�
            stockOut.Context = theData.Picker;//������
            stockOut.State = 0;
            stockOut.OutNo = $"P-{DateTime.Now.ToString("yyMMddHHmmss.fff")}";
            stockOut.OutDate = DateTime.Now;
            stockOut.OutOperID = Base_UserBusiness.GetCurrentUser().UserId;
            stockOut.OutType = 0;//0 �������ϵ�

            foreach (Pro_MaterialRequisitionItem item in theData.MaterialRequisitionModel.MReqItemList)
            {
                Sto_StockOutItem stockOutItem = new Sto_StockOutItem();
                stockOutItem.Id = Guid.NewGuid().ToSequentialGuid();
                stockOutItem.OutNo = stockOut.OutNo;
                stockOutItem.MatNo = item.MatNo;
                stockOutItem.MatName = item.MatName;
                //stockOutItem.Price = 0;
                stockOutItem.GuiGe = item.GuiGe;
                stockOutItem.UnitNo = item.UnitNo;
                stockOutItem.Quantity = item.Quantity;
                stockOut.StockOutItems.Add(stockOutItem);
            }

            this._sto_StockOutBusiness.ProMaterial(stockOut,theData.Picker,theData.MaterialRequisitionModel.ProCode, theData.MaterialRequisitionModel.ProName);

            return Success();
        }

        public ActionResult DownLoad()
        {
            object con = new SystemCache().GetCache("stockout_query");
            if (con == null) return new EmptyResult();

            var dataList = _sto_StockOutBusiness.GetStockOutList(
                $"{con.GetPropertyValue("StoreId")}",
                $"{con.GetPropertyValue("OutNo")}",
                $"{con.GetPropertyValue("B_OutDate")}",
                $"{con.GetPropertyValue("E_OutDate")}", 
                new Pagination() { PageRows=Int32.MaxValue});

            string outputFileName = $"����-{DateTime.Now.ToString("yyyyMMddHHmmss")}";
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("�ֿ�"));
            dataTable.Columns.Add(new DataColumn("���ⵥ��"));
            dataTable.Columns.Add(new DataColumn("����ʱ��"));
            dataTable.Columns.Add(new DataColumn("�������Ա"));

            dataTable.Columns.Add(new DataColumn("���ϱ���"));
            dataTable.Columns.Add(new DataColumn("��������"));
            dataTable.Columns.Add(new DataColumn("���"));
            dataTable.Columns.Add(new DataColumn("��λ"));
            dataTable.Columns.Add(new DataColumn("����"));
            dataTable.Columns.Add(new DataColumn("��������"));
            dataTable.Columns.Add(new DataColumn("������"));
            dataTable.Columns.Add(new DataColumn("��ע"));

            foreach(StockOutListItem item in dataList)
            {
                DataRow newRow = dataTable.NewRow();
                newRow[0] = item.StoreName;
                newRow[1] = item.OutNo;
                newRow[2] = item.OutDate;
                newRow[3] = item.OutOperID;
                newRow[4] = item.MatNo;
                newRow[5] = item.MatName;
                newRow[6] = item.GuiGe;
                newRow[7] = item.UnitName;
                newRow[8] = item.Quantity;
                newRow[9] = item.OutType ==0? "��������" : "��ͨ����";
                newRow[10] = item.ApplyNo;
                newRow[11] = item.Context;
                dataTable.Rows.Add(newRow);
            }
            OperateExcel.ExportToExcel(System.Web.HttpContext.Current, dataTable, outputFileName);

            return new EmptyResult();
        }

        #endregion

        public class ProMRModel
        {
            public MaterialRequisitionModel MaterialRequisitionModel { get; set; }
            public string StoreId { get; set; }
            public string Picker { get; set; }
        }


    }

    public class CatchModel
    {
        public List<Sto_Material> Entity { get; set; }
        public string Id { get; set; }
    }
}