using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class HtmlEditorController : DemoController {
        public ActionResult SpellChecking() {
            return DemoView("SpellChecking");
        }
        public ActionResult SpellCheckingPartial() {
            return PartialView("SpellCheckingPartial");
        }
        public ActionResult SpellCheckingImageUpload() {
            HtmlEditorExtension.SaveUploadedImage("heSpellChecking", HtmlEditorDemosHelper.ImageUploadValidationSettings, HtmlEditorDemosHelper.UploadDirectory);
            return null;
        }
    }
}
