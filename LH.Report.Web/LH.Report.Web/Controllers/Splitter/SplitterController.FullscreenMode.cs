using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class SplitterController: DemoController {
        public ActionResult FullscreenMode() {
            return DemoView("FullscreenMode");
        }
        public ActionResult FullscreenModePage() {
            return View();
        }
    }
}
