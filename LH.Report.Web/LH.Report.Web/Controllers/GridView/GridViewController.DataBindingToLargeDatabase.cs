using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult DataBindingToLargeDatabase() {
            return DemoView("DataBindingToLargeDatabase");
        }
        public ActionResult DataBindingToLargeDatabasePartial() {
            return PartialView("DataBindingToLargeDatabasePartial");
        }
    }
}
