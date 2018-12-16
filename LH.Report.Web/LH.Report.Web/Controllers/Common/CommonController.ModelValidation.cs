using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class CommonController: DemoController {
        [HttpGet]
        public ActionResult ModelValidation() {
            return DemoView("ModelValidation", new ModelValidationData());
        }
        [HttpPost]
        public ActionResult ModelValidation(ModelValidationData validationData) {
            if (Request.Params["btnUpdate"] == null) { // Theme changing
                ModelState.Clear();
                return DemoView("ModelValidation", validationData);
            }

            if (ModelState.IsValid) {
                object redirectActionName = "ModelValidation";
                return DemoView("ModelValidation", "ValidationSuccess", redirectActionName);
            }
            else
                return DemoView("ModelValidation", validationData);
        }
    }
}
