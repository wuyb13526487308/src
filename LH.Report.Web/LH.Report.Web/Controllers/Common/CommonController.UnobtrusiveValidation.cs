using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class CommonController: DemoController {
        [HttpGet]
        public ActionResult UnobtrusiveValidation() {
            return DemoView("UnobtrusiveValidation", new UnobtrusiveValidationData());
        }
        [HttpPost]
        public ActionResult UnobtrusiveValidation(UnobtrusiveValidationData validationData) {
            if (Request.Params["btnUpdate"] == null) { // Theme changing
                ModelState.Clear();
                return DemoView("UnobtrusiveValidation", validationData);
            }

            if (ModelState.IsValid) {
                object redirectActionName = "UnobtrusiveValidation";
                return DemoView("UnobtrusiveValidation", "ValidationSuccess", redirectActionName);
            }
            else
                return DemoView("UnobtrusiveValidation", validationData);
        }
    }
}
