using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class NavBarController: DemoController {
        public ActionResult ClientSideEvents() {
            return ClientSideEventsDemoView(new string[]{
                "Init",
                "ItemClick",
                "HeaderClick",
                "ExpandedChanging",
                "ExpandedChanged"
            });
        }
    }
}
