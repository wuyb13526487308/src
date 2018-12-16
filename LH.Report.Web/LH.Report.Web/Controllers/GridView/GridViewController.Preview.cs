using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult Preview() {
            return DemoView("Preview", NorthwindDataProvider.GetEmployees());
        }
        public ActionResult PreviewPartial() {
            return PartialView("PreviewPartial", NorthwindDataProvider.GetEmployees());
        }
    }
}
