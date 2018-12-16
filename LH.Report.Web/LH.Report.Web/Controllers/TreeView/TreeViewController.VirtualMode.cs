using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeViewController: DemoController {
        public ActionResult VirtualMode() {
            return DemoView("VirtualMode");
        }
        public ActionResult VirtualModePartial() {
            return PartialView("VirtualModePartial");
        }
    }
}
