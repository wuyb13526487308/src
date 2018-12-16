using System.Web.Mvc;
using DevExpress.Web.ASPxHtmlEditor;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class HtmlEditorController : DemoController {
        [HttpGet]
        public ActionResult Validation() {
            ViewData["ActiveView"] = HtmlEditorView.Design;
            string htmlContentPath = Server.MapPath("~/Content/HtmlEditor/DemoHtml/Validation.htm");
            ViewData["Html"] = System.IO.File.ReadAllText(htmlContentPath);
            return DemoView("Validation");
        }
        [HttpPost]
        public ActionResult Validation(FormCollection form) {
            bool isValid = true;
            ViewData["ActiveView"] = HtmlEditorExtension.GetActiveView("heValidation");
            ViewData["Html"] = HtmlEditorExtension.GetHtml("heValidation", null, HtmlEditorDemosHelper.ValidationSettings, HtmlEditorDemosHelper.OnValidation, out isValid);
            if(isValid)
                return DemoView("Validation", "ValidationSuccess");
            else
                return DemoView("Validation");
        }
        public ActionResult ValidationPartial() {
            return PartialView("ValidationPartial");
        }
        public ActionResult ValidationImageUpload() {
            HtmlEditorExtension.SaveUploadedImage("heValidation", HtmlEditorDemosHelper.ImageUploadValidationSettings, HtmlEditorDemosHelper.UploadDirectory);
            return null;
        }
    }
}
