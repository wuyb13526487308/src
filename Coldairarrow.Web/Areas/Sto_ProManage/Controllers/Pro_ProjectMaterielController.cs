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

        #region 视图功能

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

        #region 获取数据

        /// <summary>
        /// 获取数据列表
        /// </summary>
        /// <param name="condition">查询类型</param>
        /// <param name="keyword">关键字</param>
        /// <returns></returns>
        public ActionResult GetDataList(string condition, string keyword, Pagination pagination)
        {
            var dataList = _pro_ProjectMaterielBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        #endregion

        #region 提交数据

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="theData">物料数据</param>
        public ActionResult AddMateriel(MaterielParam theData)
        {
            if (theData == null || theData.ProCode == "")
                return Error("传入参数错误");
            if (theData.MaterielList == null || theData.MaterielList.Count == 0)
                return Error("没有添加任何物料");

            //直接创建领料单
            _pro_ProjectMaterielBusiness.AddData(theData);

            return Success();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public ActionResult DeleteData(string ids)
        {
            _pro_ProjectMaterielBusiness.DeleteData(ids.ToList<string>());

            return Success("删除成功！");
        }



        #endregion

        public ActionResult CreateTempMaterialList(CreateTempMaterielParam parm)
        {
            var items = new List<Pro_UseMateriel>();
            //创建新增材料列表
            //1.根据模板ID读取模板
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