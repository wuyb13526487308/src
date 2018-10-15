﻿using Coldairarrow.Business;
using Coldairarrow.Entity.Base_SysManage;
using Coldairarrow.Util;
using System;
using System.Web;
using System.Web.Mvc;

namespace Coldairarrow.Web
{
    /// <summary>
    /// Mvc基控制器
    /// </summary>
    public class BaseController : Controller
    {
        /// <summary>
        /// 在调用操作方法前调用
        /// </summary>
        /// <param name="filterContext">请求上下文</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var sessionCookie = HttpContext.Request.Cookies[SessionHelper.SessionCookieName];
            if (sessionCookie.IsNullOrEmpty())
            {
                string sessionId = Guid.NewGuid().ToString();
                sessionCookie = new HttpCookie(SessionHelper.SessionCookieName, sessionId)
                {
                    Expires = DateTime.MaxValue
                };
                HttpContext.Request.Cookies.Add(sessionCookie);
                HttpContext.Response.Cookies.Add(sessionCookie);
            }
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <returns></returns>
        public ContentResult Success()
        {
            AjaxResult res = new AjaxResult
            {
                Success = true,
                Msg = "请求成功！",
                Data = null
            };

            return Content(res.ToJson());
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public ContentResult Success(string msg)
        {
            AjaxResult res = new AjaxResult
            {
                Success = true,
                Msg = msg,
                Data = null
            };

            return Content(res.ToJson());
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="data">返回的数据</param>
        /// <returns></returns>
        public ContentResult Success(object data)
        {
            AjaxResult res = new AjaxResult
            {
                Success = true,
                Msg = "请求成功！",
                Data = data
            };

            return Content(res.ToJson());
        }

        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="msg">返回的消息</param>
        /// <param name="data">返回的数据</param>
        /// <returns></returns>
        public ContentResult Success(string msg, object data)
        {
            AjaxResult res = new AjaxResult
            {
                Success = true,
                Msg = msg,
                Data = data
            };

            return Content(res.ToJson());
        }

        /// <summary>
        /// 返回错误
        /// </summary>
        /// <returns></returns>
        public ContentResult Error()
        {
            AjaxResult res = new AjaxResult
            {
                Success = false,
                Msg = "请求失败！",
                Data = null
            };

            return Content(res.ToJson());
        }

        /// <summary>
        /// 返回错误
        /// </summary>
        /// <param name="msg">错误提示</param>
        /// <returns></returns>
        public ContentResult Error(string msg)
        {
            AjaxResult res = new AjaxResult
            {
                Success = false,
                Msg = msg,
                Data = null
            };

            return Content(res.ToJson());
        }

        /// <summary>
        /// 返回数据表格数据
        /// 注：Easyui的DataGrid
        /// </summary>
        /// <param name="dataList">数据列表</param>
        /// <param name="pagination">分页参数</param>
        /// <returns></returns>
        public ActionResult DataTable_Easyui(object dataList, Pagination pagination)
        {
            return Content(pagination.BuildTableResult_DataGrid(dataList).ToJson());
        }

        /// <summary>
        /// 当前URL是否包含某字符串
        /// 注：忽略大小写
        /// </summary>
        /// <param name="subUrl">包含的字符串</param>
        /// <returns></returns>
        public bool UrlContains(string subUrl)
        {
            return Request.Url.ToString().ToLower().Contains(subUrl.ToLower());
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logContent">日志内容</param>
        /// <param name="logType">日志类型</param>
        public static void WriteSysLog(string logContent, EnumType.LogType logType)
        {
            BaseBusiness<object>.WriteSysLog(logContent, logType);
        }

        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="logContent">日志内容</param>
        public void WriteSysLog(string logContent)
        {
            WriteSysLog(logContent, LogType);
        }

        /// <summary>
        /// 日志类型
        /// 注：可通过具体控制器重写
        /// </summary>
        public virtual EnumType.LogType LogType
        {
            get
            {
                throw new Exception("请在子类重写日志类型");
            }
        }
    }
}