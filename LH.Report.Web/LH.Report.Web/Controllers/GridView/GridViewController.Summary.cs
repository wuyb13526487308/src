using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult Summary() {
            return DemoView("Summary", NorthwindDataProvider.GetInvoices());
        }
        public ActionResult SummaryPartial() {
            return PartialView("SummaryPartial", NorthwindDataProvider.GetInvoices());
        }
    }
}
