using System;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class PivotGridController: DemoController {
        public ActionResult Templates() {
            return DemoView("Templates", NorthwindDataProvider.GetProductReports());
        }
        public ActionResult TemplatesPartial() {
            return PartialView("TemplatesPartial", NorthwindDataProvider.GetProductReports());
        }
    }
}
