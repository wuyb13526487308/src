using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class LoadingPanelController : DemoController {
        [HttpGet]
        public ActionResult Example() {
            ViewData["DisplayOverPanel"] = true;
            return DemoView("Example");
        }
        [HttpPost]
        public ActionResult Example(bool displayOverPanel) {
            ViewData["DisplayOverPanel"] = displayOverPanel;
            return DemoView("Example");
        }
        public ActionResult ExamplePartial() {
            return PartialView("ExamplePartial");
        }
    }
}
