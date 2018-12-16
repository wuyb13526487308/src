using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class MenuController: DemoController {
        public ActionResult Templates() {
            return DemoView("Templates");
        }
    }
}
