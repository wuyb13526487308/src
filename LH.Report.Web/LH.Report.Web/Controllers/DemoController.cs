﻿using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxClasses.Internal;
using System.Web.Mvc;
using System.Web.UI;

namespace DevExpress.Web.Demos {
    public abstract class DemoController: Controller {
        public const string ViewTitleSuffix = "DevExpress ASP.NET MVC Extensions";

        public abstract string Name { get; }

        public ActionResult DemoView(string actionName) {
            return DemoView(actionName, actionName, null);
        }
        public ActionResult DemoView(string actionName, object model) {
            return DemoView(actionName, actionName, model);
        }
        public ActionResult DemoView(string actionName, string viewName) {
            return DemoView(actionName, viewName, null);
        }
        public ActionResult DemoView(string actionName, string viewName, object model) {
            Utils.RegisterCurrentMvcDemo(Name, actionName);
            return (model != null) ? View(viewName, model) : View(viewName);
        }

        // Specific views
        public ActionResult ClientSideEventsDemoView(string[] events) {
            ViewData["ClientSideEvents"] = events;
            return DemoView("ClientSideEvents");
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext) {
            base.OnActionExecuted(filterContext);
            if (RenderUtils.Browser.IsIE) {
                
                bool isDemoRequiredCompatibilityMode = IsDemoRequiredCompatibilityMode();
                if (isDemoRequiredCompatibilityMode)
                    ASPxWebControl.SetIECompatibilityMode(IECompatibilityVersion);
                else
                    ASPxWebControl.SetIECompatibilityModeEdge();

                var IEVersion = isDemoRequiredCompatibilityMode ? IECompatibilityVersion.ToString() : "edge";
                ViewData["MetaContent"] = string.Format("<meta http-equiv=\"X-UA-Compatible\" content=\"IE={0}\" />", IEVersion);
            }
        }
        protected virtual int IECompatibilityVersion { get { return -1;} }
        protected virtual bool IsDemoRequiredCompatibilityMode() {
            return false;
        }
    }

    public class DemosHelper {
        public static string GetFieldText(object data, string fieldName) {
            object text = DataBinder.Eval(data, fieldName);
            if (text == null || text.ToString() == string.Empty)
                return "&nbsp";
            return text.ToString();
        }
    }
}
