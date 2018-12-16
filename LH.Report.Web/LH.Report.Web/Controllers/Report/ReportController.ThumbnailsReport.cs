using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult ThumbnailsReport() {
            return DemoView("ThumbnailsReport", "ThumbnailsViewer", ReportDemoHelper.CreateModel("Thumbnails"));
        }

        public FileResult ThumbnailsImageHandler(string img) {
            return File(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Thumbnails/" + img), "image/png");
        }
    }
}
