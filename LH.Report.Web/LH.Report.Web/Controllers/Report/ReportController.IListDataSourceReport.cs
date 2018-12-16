using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult IListDataSourceReport() {
            return DemoView("IListDataSourceReport", "SampleViewer", ReportDemoHelper.CreateModel("IListDataSource"));
        }
    }
}
