using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class MenuController : DemoController {
        public ActionResult ClientSideEvents() {
            return ClientSideEventsDemoView(new string[]{
                "Init",
                "ItemClick",
                "PopUp",
                "CloseUp",
                "ItemMouseOver",
                "ItemMouseOut"
            });
        }
    }
}
