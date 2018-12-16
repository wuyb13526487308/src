using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TabControlController: DemoController {
        public ActionResult Templates() {
            return DemoView("Templates");
        }
        public ActionResult TemplatesActiveTab() {
            return PartialView();
        }
        public ActionResult TemplatesTab() {
            return PartialView();
        }
    }
}
