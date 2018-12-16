using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult PivotGridAndChartReport() {
            return DemoView("PivotGridAndChartReport", "SampleViewer", ReportDemoHelper.CreateModel("PivotGridAndChart"));
        }
    }
}
