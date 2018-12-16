using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        public ActionResult NodePreview() {
            return DemoView("NodePreview", FishCatalog.GetData());
        }
        public ActionResult NodePreviewPartial() {
            return PartialView("NodePreviewPartial", FishCatalog.GetData());
        }
    }
}
