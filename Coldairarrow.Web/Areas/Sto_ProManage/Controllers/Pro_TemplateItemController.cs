using Coldairarrow.Business.Sto_BaseInfo;
using Coldairarrow.Business.Sto_ProManage;
using Coldairarrow.Entity.Sto_BaseInfo;
using Coldairarrow.Entity.Sto_ProManage;
using Coldairarrow.Util;
using System;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    public class Pro_TemplateItemController : BaseMvcController
    {
        Pro_TemplateItemBusiness _pro_TemplateItemBusiness = new Pro_TemplateItemBusiness();
        Sto_MaterialBusiness _sto_MaterialBusiness = new Sto_MaterialBusiness();
        static SystemCache _systemCache = new SystemCache();

        #region ��ͼ����

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            Pro_TemplateItem theData = null;
            if (id.Contains("cache_"))
            {
                string str = id.Replace("cache_", "");
                Sto_Material mat = _sto_MaterialBusiness.GetEntity(str);
                theData = new Pro_TemplateItem()
                {
                    MatName = mat.MatName,
                    MatNo = mat.MatNo,
                    UnitNo = mat.UnitNo,
                    GuiGe = mat.GuiGe,
                    Context = mat.Context
                };
            }
            else
            {
                theData = id.IsNullOrEmpty() ? new Pro_TemplateItem() { Id = Guid.NewGuid().ToSequentialGuid() } : _pro_TemplateItemBusiness.GetEntity(id);
                if (theData == null)
                {
                    theData = new Pro_TemplateItem()
                    {
                        Id = Guid.NewGuid().ToSequentialGuid()
                    };
                }
            }
            return View(theData);
        }

        public ActionResult FindCacheItem(string id)
        {
            id = "12345";
            var theData = _systemCache.GetCache<Pro_TemplateItem>(id);
            if (theData == null)
            {
                theData = new Pro_TemplateItem();
            }
            else
            {
                //�������
                _systemCache.RemoveCache(id);
            }

            return Content(theData.ToJson());
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
            var dataList = _pro_TemplateItemBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }



        #endregion

        #region �ύ����

        /// <summary>
        /// ����������Ŀ(���ڴ��������ϵ�ģ��ʱʹ��)
        /// </summary>
        /// <param name="theData"></param>
        /// <returns></returns>
        public ActionResult CreateCacheItem(Pro_TemplateItem theData)
        {
            theData.Id = "12345";
            if (theData.Id.IsNullOrEmpty())
            {
                return Error("�½���Id��Ϊ��");
            }
            else
            {
                _systemCache.SetCache(theData.Id, theData, new TimeSpan(0, 1, 0));
            }
            return Success();
        }

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="theData">���������</param>
        public ActionResult SaveData(Pro_TemplateItem theData)
        {
            if(theData.Id.IsNullOrEmpty())
            {
                theData.Id = Guid.NewGuid().ToSequentialGuid();

                _pro_TemplateItemBusiness.AddData(theData);
            }
            else
            {
                _pro_TemplateItemBusiness.UpdateData(theData);
            }

            return Success();
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public ActionResult DeleteData(string ids)
        {
            _pro_TemplateItemBusiness.DeleteData(ids.ToList<string>());

            return Success("ɾ���ɹ���");
        }

        #endregion
    }
}