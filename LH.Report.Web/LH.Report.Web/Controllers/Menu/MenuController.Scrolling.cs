using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class MenuController: DemoController {
        public ActionResult Scrolling() {
            return DemoView("Scrolling", new string[] { "ScrollingFrame.aspx" });
        }
        public ActionResult ScrollingFrame() {
            return DemoView("ScrollingFrame");
        }
    }
}
