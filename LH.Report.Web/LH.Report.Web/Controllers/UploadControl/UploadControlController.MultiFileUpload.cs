using System.Web.Mvc;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class UploadControlController : DemoController {
        [HttpGet]
        public ActionResult MultiFileUpload() {
            Session["Storage"] = new UploadControlFilesStorage();
            return DemoView("MultiFileUpload");
        }
        [HttpPost]
        public ActionResult MultiFileUpload(FormCollection form) {
            if(Request.Params["add"] != null) {
                UploadedFile[] files = UploadControlExtension.GetUploadedFiles("ucMultiFile", UploadControlDemosHelper.ValidationSettings);
                UploadControlDemosHelper.AddImagesToCollection(files);
            }
            else if(Request.Params["clear"] != null) {
                UploadControlDemosHelper.ClearImageCollection();
            }
            return DemoView("MultiFileUpload");
        }
    }
}
