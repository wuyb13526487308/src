using Coldairarrow.Business.Sto_ProManage;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using static Coldairarrow.Business.Sto_ProManage.Pro_ProjectMaterielBusiness;

namespace Coldairarrow.Web
{
    public class Pro_ProjectMaterielController : BaseMvcController
    {
        Pro_ProjectMaterielBusiness _pro_ProjectMaterielBusiness = new Pro_ProjectMaterielBusiness();

        #region ��ͼ����

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            var theData = id.IsNullOrEmpty() ? new Pro_ProjectMateriel() : _pro_ProjectMaterielBusiness.GetTheData(id);

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
            var dataList = _pro_ProjectMaterielBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        #endregion

        #region �ύ����

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="theData">��������</param>
        public ActionResult AddMateriel(MaterielParam theData)
        {
            if (theData == null || theData.ProCode == "")
                return Error("�����������");
            if (theData.MaterielList == null || theData.MaterielList.Count == 0)
                return Error("û������κ�����");

            //ֱ�Ӵ������ϵ�
            _pro_ProjectMaterielBusiness.AddData(theData);

            return Success();
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public ActionResult DeleteData(string ids)
        {
            _pro_ProjectMaterielBusiness.DeleteData(ids.ToList<string>());

            return Success("ɾ���ɹ���");
        }



        #endregion

        public ActionResult CreateTempMaterialList(CreateTempMaterielParam parm)
        {
            var items = new List<Pro_UseMateriel>();
            //�������������б�
            //1.����ģ��ID��ȡģ��
            Pro_TemplateItemBusiness tb = new Pro_TemplateItemBusiness();
            var tempList = tb.GetDataList("TemplateId", parm.TemplateId, new Pagination() { PageIndex=1,PageRows=int.MaxValue});
            tempList.ForEach(item =>
            {
                items.Add(new Pro_UseMateriel()
                {
                    Id= Guid.NewGuid().ToSequentialGuid(),
                    ProCode= parm.ProCode,
                    GuiGe = item.GuiGe,
                    MatName = item.MatName,
                    UnitNo = item.UnitNo,
                    MatNo = item.MatNo,
                    Quantity = item.Quantity * parm.CreateCount
                });
            });
            return Content(items.ToJson());
        }


        public class CreateTempMaterielParam
        {
            // proCode: proCode, templateId: templateId, createCount: createCount
            public string ProCode { get; set; }
            public string TemplateId { get; set; }
            public int CreateCount { get; set; }
        }    
    }
}