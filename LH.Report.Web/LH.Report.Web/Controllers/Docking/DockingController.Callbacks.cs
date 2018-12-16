using System;
using System.Threading;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class DockingController : DemoController {
        public ActionResult Callbacks() {
            ViewData["OwnerZoneUID"] = "developmentDepartmentZone";
            return DemoView("Callbacks");
        }
        public ActionResult CallbacksPartial() {
            if(DevExpressHelper.IsCallback)
                Thread.Sleep(500);
            ViewData["OwnerZoneUID"] = Convert.ToString(Request.Params["OwnerZoneUID"]);
            return PartialView("CallbacksPartial");
        }
    }
}
