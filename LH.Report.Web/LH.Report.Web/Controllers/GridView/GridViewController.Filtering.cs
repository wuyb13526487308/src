using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        [HttpGet]
        public ActionResult Filtering() {
            Session["EnableCheckedListMode"] = true;
            return DemoView("Filtering", NorthwindDataProvider.GetInvoices());
        }
        [HttpPost]
        public ActionResult Filtering(bool enableCheckedListMode) {
            Session["EnableCheckedListMode"] = enableCheckedListMode;
            return DemoView("Filtering", NorthwindDataProvider.GetInvoices());
        }
        public ActionResult FilteringPartial() {
            return PartialView("FilteringPartial", NorthwindDataProvider.GetInvoices());
        }
    }
}
