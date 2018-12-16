using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class UploadControlController : DemoController {
        public ActionResult Callbacks() {
            return DemoView("Callbacks");
        }
        public ActionResult CallbacksImageUpload() {
            UploadControlExtension.GetUploadedFiles("ucCallbacks", UploadControlDemosHelper.ValidationSettings, UploadControlDemosHelper.ucCallbacks_FileUploadComplete);
            return null;
        }
    }
}
