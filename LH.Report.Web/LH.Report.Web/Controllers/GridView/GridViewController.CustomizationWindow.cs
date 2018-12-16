using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult CustomizationWindow() {
            return DemoView("CustomizationWindow", NorthwindDataProvider.GetCustomers());
        }
        public ActionResult CustomizationWindowPartial() {
            return PartialView("CustomizationWindowPartial", NorthwindDataProvider.GetCustomers());
        }
    }
}
