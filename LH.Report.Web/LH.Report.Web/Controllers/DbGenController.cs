using System;
using System.Web.Mvc;
using System.Web;
using System.Collections;

namespace DevExpress.Web.Demos {

    public class DbGenController : Controller {        

        public ActionResult Create() {
            return new JsonResult {
                Data = DatabaseGenerator.TryCreateDatabase(GetTableKey())
            };
        }
        public ActionResult GetRecordCount() {
            return new JsonResult {
                Data = DatabaseGenerator.GetCreatingDatabaseRecordCount(GetTableKey())
            };
        }

        string GetTableKey() {
            return Request.Params["tableKey"];
        }

        protected override void OnException(ExceptionContext filterContext) {
            filterContext.Result = new ContentResult() {
                Content = filterContext.Exception.Message,
                ContentType = "text/plain"
            };
            filterContext.ExceptionHandled = true;
            Response.StatusCode = 500;
        }
    }
}
