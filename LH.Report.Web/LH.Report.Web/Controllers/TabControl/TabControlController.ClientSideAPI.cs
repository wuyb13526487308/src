using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TabControlController: DemoController {
        public ActionResult ClientSideAPI() {
            return DemoView("ClientSideAPI");
        }
    }
}
