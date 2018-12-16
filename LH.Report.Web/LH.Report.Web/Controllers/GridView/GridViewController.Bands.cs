using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult Bands() {
            return DemoView("Bands", NorthwindDataProvider.GetFullInvoices());
        }
        public ActionResult BandsPartial() {
            return PartialView("BandsPartial", NorthwindDataProvider.GetFullInvoices());
        }
    }
}
