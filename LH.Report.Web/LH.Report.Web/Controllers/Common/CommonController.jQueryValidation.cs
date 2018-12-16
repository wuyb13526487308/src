using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class CommonController: DemoController {
        [HttpGet]
        public ActionResult jQueryValidation() {
            return DemoView("jQueryValidation", new JQueryValidationData());
        }
        [HttpPost]
        public ActionResult jQueryValidation(JQueryValidationData validationData) {
            if (Request.Params["btnUpdate"] == null) { // Theme changing
                ModelState.Clear();
                return DemoView("jQueryValidation", validationData);
            }

            if (ModelState.IsValid) {
                object redirectActionName = "jQueryValidation";
                return DemoView("jQueryValidation", "ValidationSuccess", redirectActionName);
            }
            else
                return DemoView("jQueryValidation", validationData);
        }
        public JsonResult CheckReleaseDate(DateTime? ReleaseDate) {
            return Json(ReleaseDate != null && ReleaseDate >= DateTime.Today, JsonRequestBehavior.AllowGet);
        }
    }
}
