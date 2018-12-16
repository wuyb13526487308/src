using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult FocusedRow() {
            return DemoView("FocusedRow", NorthwindDataProvider.GetEmployees());
        }
        public ActionResult FocusedRowPartial() {
            return PartialView("FocusedRowPartial", NorthwindDataProvider.GetEmployees());
        }
    }
}
