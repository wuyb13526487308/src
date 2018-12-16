using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class UploadControlController : DemoController {
        public ActionResult MultiFileSelection() {
            return DemoView("MultiFileSelection");
        }
        public ActionResult MultiSelectionImageUpload() {
            UploadControlExtension.GetUploadedFiles("ucMultiSelection", UploadControlDemosHelper.ValidationSettings, UploadControlDemosHelper.ucMultiSelection_FileUploadComplete);
            return null;
        }
        public ActionResult MultiFileSelectionPartial() {
            return PartialView("MultiFileSelectionPartial");
        }
    }
}
