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

        #region ��ͼ����

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

        #region ��ȡ����

        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <param name="keyword">�ؼ���</param>
        /// <returns></returns>
        public ActionResult GetDataList(string condition, string keyword, Pagination pagination)
        {
            var dataList = _pro_MaterialRequisitionBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        #endregion

        #region �ύ����

        /// <summary>
        /// ���������޸�
        /// </summary>
        /// <param name="theData">���������</param>
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
        /// ɾ�����ϵ�
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public ActionResult DeleteData(string ids)
        {

            string result = _pro_MaterialRequisitionBusiness.DeleteData(ids.ToList<string>());
            if (result == "")
            {
                return Success("ɾ���ɹ���");
            }
            else
            {
                return Error(result);
            }
        }

        public ActionResult RemoveRowToCached(string mrId,string itemId)
        {
            //��ȡ���������
            List<string> ids = _systemCache.GetCache(mrId) as List<String>;
            if (ids == null)
            {
                ids = new List<string>();
            }
            ids.Add(itemId);
            _systemCache.SetCache(mrId, ids, new TimeSpan(1, 1, 0));
            return Success("�ɹ���");
        }

        public ActionResult ClearCached(string mrId)
        {
            _systemCache.RemoveCache(mrId);
            return Success();
        }

        #endregion
    }
}