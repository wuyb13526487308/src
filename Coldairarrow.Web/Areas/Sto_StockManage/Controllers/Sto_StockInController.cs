using Coldairarrow.Business.Base_SysManage;
using Coldairarrow.Business.Sto_StockManage;
using Coldairarrow.Entity.Sto_StockManage;
using Coldairarrow.Util;
using System;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    public class Sto_StockInController : BaseMvcController
    {
        Sto_StockInBusiness _sto_StockInBusiness = new Sto_StockInBusiness();
        


        #region ��ͼ����

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            var theData = id.IsNullOrEmpty() ? new StockInModel() : _sto_StockInBusiness.GetTheData(id);

            return View(theData);
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
            var dataList = _sto_StockInBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        #endregion

        #region �ύ����

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="theData">���������</param>
        public ActionResult SaveData(StockInModel theData)
        {
            if(theData.Id.IsNullOrEmpty())
            {
                _sto_StockInBusiness.AddData(theData);
            }
            else
            {
                _sto_StockInBusiness.UpdateData(theData);
            }

            return Success();
        }

        public ActionResult AuditorStockIn(string ids)
        {
            string operName =  Base_UserBusiness.GetCurrentUser().RealName;
            this._sto_StockInBusiness.AuditorStockIn(ids.ToList<String>(), operName);
            return Success();
        }

        public ActionResult UnAuditorStockIn(string ids)
        {
            string operName = Base_UserBusiness.GetCurrentUser().RealName;
            this._sto_StockInBusiness.UnAuditorStockIn(ids.ToList<String>(), operName);
            return Success();
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public ActionResult DeleteData(string ids)
        {
            _sto_StockInBusiness.DeleteData(ids.ToList<string>());

            return Success("ɾ���ɹ���");
        }

        #endregion
    }
}