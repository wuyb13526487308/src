using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class NavBarController: DemoController {
        [HttpGet]
        public ActionResult Features() {
            ViewData["Options"] = new NavBarFeaturesDemoOptions();
            return DemoView("Features");
        }
        [HttpPost]
        public ActionResult Features([Bind]NavBarFeaturesDemoOptions options) {
            ViewData["Options"] = options;
            return DemoView("Features");
        }
    }
}
