using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;

namespace DevExpress.Web.Demos {
    public partial class PivotGridController: DemoController {
        public ActionResult SampleReports() {
            Session["ReportOptions"] = PivotGridReportsDemoOptions.Default;
            return DemoView("SampleReports", NorthwindDataProvider.GetCustomerReports());
        }
        public ActionResult SampleReportsPartial() {
            return PartialView("SampleReportsPartial", NorthwindDataProvider.GetCustomerReports());
        }
        public ActionResult CustomActionSampleReportsPartial(PivotGridReportsDemoOptions options) {
            if (options != null) {
                Session["ReportOptions"] = options;
                ViewBag.IsReloadLayout = true;
            }
            return PartialView("SampleReportsPartial", NorthwindDataProvider.GetCustomerReports());
        }
    }
}
