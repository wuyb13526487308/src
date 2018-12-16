using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Threading;

namespace DevExpress.Web.Demos {
    public partial class CommonController: DemoController {
        public ActionResult AjaxForm() {
            return DemoView("AjaxForm", new AjaxFormValidationData());
        }
        [HttpPost]
        public ActionResult AjaxForm(AjaxFormValidationData validationData) {
            if (!Request.IsAjaxRequest()) { // Theme changing
                ModelState.Clear();
                return DemoView("AjaxForm", validationData);
            }

            // Intentionally pauses server-side processing, 
            // to demonstrate the Loading Panel functionality.
            Thread.Sleep(1000); 
            if (ModelState.IsValid) {
                object redirectActionName = "AjaxForm";
                return PartialView("ValidationSuccessPartial", redirectActionName);
            }
            else
                return PartialView("AjaxFormPartial", validationData);
        }
    }
}
