using System;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class PivotGridController: DemoController {
        public ActionResult OLAP() {
            return DemoView("OLAP");
        }
        public ActionResult OLAPPartial() {
            return PartialView("OLAPPartial");
        }
    }
}
