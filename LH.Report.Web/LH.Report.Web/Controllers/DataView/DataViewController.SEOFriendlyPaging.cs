using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class DataViewController : DemoController {
        public ActionResult SEOFriendlyPaging() {
            return DemoView("SEOFriendlyPaging", NorthwindDataProvider.GetEmployees());
        }
        public ActionResult SEOFriendlyPagingPartial() {
            return PartialView("SEOFriendlyPagingPartial", NorthwindDataProvider.GetEmployees());
        }
    }
}
