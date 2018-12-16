using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult ReportMerging() {
            return DemoView("ReportMerging", "SampleViewer", ReportDemoHelper.CreateModel("ReportMerging"));
        }
    }
}
