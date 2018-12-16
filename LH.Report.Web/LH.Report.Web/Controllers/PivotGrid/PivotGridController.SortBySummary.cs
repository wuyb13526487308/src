using System;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class PivotGridController: DemoController {
        [HttpGet]
        public ActionResult SortBySummary() {
            Session["SortField"] = "Order Amount";
            return DemoView("SortBySummary", NorthwindDataProvider.GetFullInvoices());
        }
        [HttpPost]
        public ActionResult SortBySummary([Bind]string SortByField) {
            Session["SortField"] = SortByField;
            return DemoView("SortBySummary", NorthwindDataProvider.GetFullInvoices());
        }
        public ActionResult SortBySummaryPartial() {
            return PartialView("SortBySummaryPartial", NorthwindDataProvider.GetFullInvoices());
        }
    }
}
