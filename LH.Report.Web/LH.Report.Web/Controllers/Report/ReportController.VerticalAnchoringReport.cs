using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult VerticalAnchoringReport() {
            return DemoView("VerticalAnchoringReport", "SampleViewer", ReportDemoHelper.CreateModel("VerticalAnchoring"));
        }
    }
}
