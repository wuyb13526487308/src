using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class EditorsController : DemoController {
        public ActionResult LargeDataComboBox() {
            return DemoView("LargeDataComboBox");
        }
        public ActionResult LargeDataComboBoxPartial() {
            return PartialView();
        }
    }
}
