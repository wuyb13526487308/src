using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class PopupControlController: DemoController {
        public ActionResult ClientSideEvents() {
            return ClientSideEventsDemoView(new string[]{
                "Init",
                "PopUp",
                "Shown",
                "CloseButtonClick",
                "Closing",
                "CloseUp",
            });
        }
    }
}
