using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class CommonController: DemoController {
        public ActionResult EditorTemplates() {
            return DemoView("EditorTemplates", new EditorTemplatesData());
        }
        [HttpPost]
        public ActionResult EditorTemplates(EditorTemplatesData validationData) {
            if (Request.Params["btnUpdate"] == null) { // Theme changing
                ModelState.Clear();
                return DemoView("EditorTemplates", validationData);
            }

            if (ModelState.IsValid) {
                object redirectActionName = "EditorTemplates";
                return DemoView("EditorTemplates", "ValidationSuccess", redirectActionName);
            }
            else
                return DemoView("EditorTemplates", validationData);
        }
    }
}
