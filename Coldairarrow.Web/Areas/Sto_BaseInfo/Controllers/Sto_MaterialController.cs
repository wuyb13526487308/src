using Coldairarrow.Business.Sto_BaseInfo;
using Coldairarrow.Entity.Sto_BaseInfo;
using Coldairarrow.Util;
using System;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    public class Sto_MaterialController : BaseMvcController
    {
        Sto_MaterialBusiness _sto_MaterialBusiness = new Sto_MaterialBusiness();
        static SystemCache _systemCache = new SystemCache();

        #region ��ͼ����

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            var theData = id.IsNullOrEmpty() ? new Sto_Material() : _sto_MaterialBusiness.GetTheData(id);

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
            var dataList = _sto_MaterialBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        public ActionResult QueryByMatNo(string matNo)
        {
            Sto_Material _m = _sto_MaterialBusiness.QueryMaterial(matNo);
            return Content(_m.ToJson());
        }

        #endregion

        #region �������ݺ���ȡ
        /// <summary>
        /// ���ڲ�ѯ���ϻ���id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Find(string id)
        {
            Sto_Material _o = new Sto_Material() { Id = id };
            return View(_o);
        }

        public ActionResult FindCacheItem(string id)
        {
            var theData = _systemCache.GetCache<Sto_Material>(id);
            if (theData == null)
            {
                theData = new Sto_Material();
            }
            else
            {
                //�������
                _systemCache.RemoveCache(id);
            }

            return Content(theData.ToJson());
        }


        public ActionResult CreateCacheItem(CacheMaterial theData)
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
        #endregion

        #region �ύ����

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="theData">���������</param>
        public ActionResult SaveData(Sto_Material theData)
        {
            if(theData.Id.IsNullOrEmpty())
            {
                theData.Id = Guid.NewGuid().ToSequentialGuid();

                _sto_MaterialBusiness.AddData(theData);
            }
            else
            {
                _sto_MaterialBusiness.UpdateData(theData);
            }

            return Success();
        }

        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="theData">ɾ��������</param>
        public ActionResult DeleteData(string ids)
        {
            _sto_MaterialBusiness.DeleteData(ids.ToList<string>());

            return Success("ɾ���ɹ���");
        }

        #endregion
    }

    public class CacheMaterial
    {
        public Sto_Material Entity { get; set; }
        public string Id { get; set; }
    }
}