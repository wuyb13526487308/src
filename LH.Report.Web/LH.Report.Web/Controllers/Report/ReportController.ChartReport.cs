using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult ChartReport() {
            return DemoView("ChartReport", "SampleViewer", ReportDemoHelper.CreateModel("Chart"));
        }
    }
}
