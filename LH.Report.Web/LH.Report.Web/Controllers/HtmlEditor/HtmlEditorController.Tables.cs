using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class HtmlEditorController : DemoController {
        public ActionResult Tables() {
            return DemoView("Tables");
        }
        public ActionResult TablesPartial() {
            return PartialView("TablesPartial");
        }
        public ActionResult TablesImageUpload() {
            HtmlEditorExtension.SaveUploadedImage("heTables", HtmlEditorDemosHelper.ImageUploadValidationSettings, HtmlEditorDemosHelper.UploadDirectory);
            return null;
        }
    }
}
