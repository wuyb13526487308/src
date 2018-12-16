using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult Paging() {
            return DemoView("Paging", NorthwindDataProvider.GetCustomers());
        }
        public ActionResult PagingPartial() {
            return PartialView("PagingPartial", NorthwindDataProvider.GetCustomers());
        }
    }
}
