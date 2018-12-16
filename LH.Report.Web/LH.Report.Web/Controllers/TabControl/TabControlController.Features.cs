using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TabControlController: DemoController {
        [HttpGet]
        public ActionResult Features() {
            ViewData["Options"] = new TabControlFeaturesDemoOptions();
            return DemoView("Features");
        }
        [HttpPost]
        public ActionResult Features([Bind]TabControlFeaturesDemoOptions options) {
            ViewData["Options"] = options;
            return DemoView("Features");
        }
    }
}
