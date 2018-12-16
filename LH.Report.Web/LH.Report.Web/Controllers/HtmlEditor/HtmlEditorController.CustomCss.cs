using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class HtmlEditorController : DemoController {
        public ActionResult CustomCss() {
            return DemoView("CustomCss");
        }
        public ActionResult CustomCssPartial() {
            return PartialView("CustomCssPartial");
        }
        public ActionResult CustomCssImageUpload() {
            HtmlEditorExtension.SaveUploadedImage("heCustomCss", HtmlEditorDemosHelper.ImageUploadValidationSettings, HtmlEditorDemosHelper.UploadDirectory);
            return null;
        }
    }
}
