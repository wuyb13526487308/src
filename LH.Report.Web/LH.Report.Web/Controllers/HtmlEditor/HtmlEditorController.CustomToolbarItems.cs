using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class HtmlEditorController : DemoController {
        public ActionResult CustomToolbarItems() {
            return DemoView("CustomToolbarItems");
        }
        public ActionResult CustomToolbarItemsPartial() {
            return PartialView("CustomToolbarItemsPartial");
        }
    }
}
