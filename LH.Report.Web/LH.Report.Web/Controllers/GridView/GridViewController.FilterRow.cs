using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult FilterRow() {
            return DemoView("FilterRow", NorthwindDataProvider.GetProducts());
        }
        public ActionResult FilterRowPartial() {
            return PartialView("FilterRowPartial", NorthwindDataProvider.GetProducts());
        }
    }
}
