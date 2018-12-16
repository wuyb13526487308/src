using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult XRPivotGridReport() {
            return DemoView("XRPivotGridReport", "SampleViewer", ReportDemoHelper.CreateModel("XRPivotGrid"));
        }
    }
}
