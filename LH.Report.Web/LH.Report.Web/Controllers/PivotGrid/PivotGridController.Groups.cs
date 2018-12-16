using System;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class PivotGridController: DemoController {
        public ActionResult Groups() {
            return DemoView("Groups", NorthwindDataProvider.GetProductReports());
        }
        public ActionResult GroupsPartial() {
            return PartialView("GroupsPartial", NorthwindDataProvider.GetProductReports());
        }
    }
}
