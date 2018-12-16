using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TabControlController: DemoController {
        public ActionResult ClientSideEvents() {
            return ClientSideEventsDemoView(new string[]{
                "Init",
                "TabClick",
                "ActiveTabChanging",
                "ActiveTabChanged"
            });
        }
    }
}
