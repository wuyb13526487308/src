using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class NavBarController: DemoController {
        public ActionResult ClientSideAPI() {
            return DemoView("ClientSideAPI");
        }
    }
}
