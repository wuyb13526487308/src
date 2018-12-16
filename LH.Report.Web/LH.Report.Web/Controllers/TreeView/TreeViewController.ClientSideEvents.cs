using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeViewController: DemoController {
        public ActionResult ClientSideEvents() {
            return ClientSideEventsDemoView(new string[]{
                "Init",
                "ExpandedChanging",
                "ExpandedChanged",
                "CheckedChanged",
                "NodeClick"
            });
        }
    }
}
