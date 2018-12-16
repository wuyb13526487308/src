using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult MasterDetailReport() {
            return DemoView("MasterDetailReport", "SampleViewer", ReportDemoHelper.CreateModel("MasterDetail"));
        }
    }
}
