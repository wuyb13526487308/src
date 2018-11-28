using Coldairarrow.Business.Base_SysManage;
using Coldairarrow.Business.Sto_ProManage;
using Coldairarrow.Business.Sto_StockManage;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Entity.Sto_StockManage;
using Coldairarrow.Util;
using System;
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

        public ActionResult FormShow(string id)
        {
            var theData = id.IsNullOrEmpty() ? new StockOutModel() : _sto_StockOutBusiness.GetStockOut(id);
            return View(theData);
        }

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
            var dataList = _sto_StockOutBusiness.GetStockOutList(StoreId, OutNo, B_OutDate, E_OutDate, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        #endregion

        #region �ύ����

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="theData">���������</param>
        public ActionResult SaveData(Sto_StockOut theData)
        {
            if(theData.Id.IsNullOrEmpty())
            {
                theData.Id = Guid.NewGuid().ToSequentialGuid();

                _sto_StockOutBusiness.AddData(theData);
            }
            else
            {
                _sto_StockOutBusiness.UpdateData(theData);
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
            stockOut.OutNo = theData.MaterialRequisitionModel.PMR_No;//�������ϵ���
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

        #endregion

        public class ProMRModel
        {
            public MaterialRequisitionModel MaterialRequisitionModel { get; set; }
            public string StoreId { get; set; }
            public string Picker { get; set; }
        }
    }
}