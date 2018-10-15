using Coldairarrow.Business.Base_SysManage;
using Coldairarrow.Entity.Base_SysManage;
using Coldairarrow.Util;
using System;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    public class Base_DepartmentController : BaseMvcController
    {
        Base_DepartmentBusiness _base_DepartmentBusiness = new Base_DepartmentBusiness();

        #region 视图功能

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Form(string id)
        {
            var theData = id.IsNullOrEmpty() ? new Base_Department() : _base_DepartmentBusiness.GetTheData(id);

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
            var dataList = _base_DepartmentBusiness.GetDataList(condition, keyword, pagination);

            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }


        /// <summary>
        /// 获取角色列表
        /// 注：无分页
        /// </summary>
        /// <returns></returns>
        public ActionResult GetDataList_NoPagin()
        {
            Pagination pagination = new Pagination
            {
                PageIndex = 1,
                PageRows = int.MaxValue
            };
            var dataList = _base_DepartmentBusiness.GetDataList(null, null, pagination);

            return Content(dataList.ToJson());
        }
        #endregion

        #region 提交数据

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="theData">保存的数据</param>
        public ActionResult SaveData(Base_Department theData)
        {
            if(theData.Id.IsNullOrEmpty())
            {
                theData.Id = Guid.NewGuid().ToSequentialGuid();
                theData.CreateTime = DateTime.Now;
                theData.ChildCount = 0;
                
                _base_DepartmentBusiness.AddData(theData);
            }
            else
            {
                _base_DepartmentBusiness.UpdateData(theData);
            }

            return Success();
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="theData">删除的数据</param>
        public ActionResult DeleteData(string ids)
        {
            _base_DepartmentBusiness.DeleteData(ids.ToList<string>());

            return Success("删除成功！");
        }

        #endregion
    }
}