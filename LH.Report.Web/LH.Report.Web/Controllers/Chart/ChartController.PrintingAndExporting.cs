using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        public ActionResult PrintingAndExporting() {
            return DemoView("PrintingAndExporting", MicrosoftAnnualRevenueProvider.GetMicrosoftAnnualRevenue());
        }
        public ActionResult PrintingAndExportingPartial() {
            return PartialView("PrintingAndExportingPartial", MicrosoftAnnualRevenueProvider.GetMicrosoftAnnualRevenue());
        }
    }
}
