using System.Web.Mvc;
using System.Web.UI;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        public ActionResult Templates() {
            return DemoView("Templates", FishCatalog.GetData());
        }
        public ActionResult TemplatesPartial() {
            return PartialView("TemplatesPartial", FishCatalog.GetData());
        }
        [HttpPost]
        public ActionResult LoadNotes(int id) {
            string notes = string.Empty;
            foreach(object fish in FishCatalog.GetData()) {
                if((int)DataBinder.Eval(fish, "ID") == id) {
                    notes = (string)DataBinder.Eval(fish, "Notes");
                    break;
                }
            }
            return TreeListExtension.GetCustomDataCallbackResult(notes);
        }
    }
}
