using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class SplitterController: DemoController {
        public ActionResult ClientSideAPI() {
            return DemoView("ClientSideAPI");
        }
    }
}
