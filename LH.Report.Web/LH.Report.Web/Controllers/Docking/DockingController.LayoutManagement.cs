using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class DockingController : DemoController {
        public ActionResult LayoutManagement() {
            return DemoView("LayoutManagement");
        }
        public ActionResult StartEditLayout() {
            Session["EditLayout"] = Session["Layout"];
            return RedirectToAction("EditLayout");
        }
        public ActionResult EditLayout() {
            return DemoView("EditLayout");
        }
        public ActionResult SaveLayout() {
            Session["Layout"] = Session["EditLayout"];
            return RedirectToAction("LayoutManagement");
        }
        public ActionResult RestoreLayout() {
            Session["EditLayout"] = Session["InitialLayout"];
            return DemoView("EditLayout");
        }
        public ActionResult EditLayoutPartial() {
            return PartialView("EditLayoutPartial");
        }
    }
}
