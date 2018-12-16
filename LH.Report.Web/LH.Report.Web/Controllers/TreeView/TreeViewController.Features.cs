using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeViewController: DemoController {
        [HttpGet]
        public ActionResult Features() {
            ViewData["Options"] = new TreeViewFeaturesDemoOptions();
            return DemoView("Features");
        }
        [HttpPost]
        public ActionResult Features([Bind]TreeViewFeaturesDemoOptions options) {
            ViewData["Options"] = options;
            return DemoView("Features");
        }
    }
}
