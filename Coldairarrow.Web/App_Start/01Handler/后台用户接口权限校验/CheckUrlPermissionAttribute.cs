﻿using Coldairarrow.Util;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    /// <summary>
    /// 校验用户接口权限
    /// </summary>
    public class CheckUrlPermissionAttribute : FilterAttribute, IActionFilter
    {
        /// <summary>
        /// Action执行之前执行
        /// </summary>
        /// <param name="filterContext">过滤器上下文</param>
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //若为本地测试，则不需要校验
            if (GlobalSwitch.RunModel == RunModel.LocalTest)
            {
                return;
            }
            //判断是否需要校验
            bool needCheck = filterContext.ContainsAttribute<CheckUrlPermissionAttribute>() && !filterContext.ContainsAttribute<IgnoreUrlPermissionAttribute>();
            if (!needCheck)
                return;

            var allUrlPermissions = UrlPermissionManage.GetAllUrlPermissions();
            string requestUrl = filterContext.HttpContext.Request.Url.ToString().ToLower();
            var thePermission = allUrlPermissions.Where(x => requestUrl.Contains(x.Url.ToLower())).FirstOrDefault();
            if (thePermission == null)
                return;
            string needPermission = thePermission.PermissionValue;
            bool hasPermission = PermissionManage.GetOperatorPermissionValues().Any(x => x.ToLower() == needPermission.ToLower());
            if (hasPermission)
                return;
            else
            {
                AjaxResult res = new AjaxResult
                {
                    Success = false,
                    Msg = "权限不足！无法访问！"
                };
                filterContext.Result = new ContentResult { Content = res.ToJson(), ContentEncoding = Encoding.UTF8 };
            }
        }

        /// <summary>
        /// Action执行完毕之后执行
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }
    }
}