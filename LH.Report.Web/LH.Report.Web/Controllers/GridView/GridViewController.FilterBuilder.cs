using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Demos;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult FilterBuilder() {
            return DemoView("FilterBuilder", NorthwindDataProvider.GetFullInvoices());
        }
        public ActionResult FilterBuilderPartial() {
            return PartialView("FilterBuilderPartial", NorthwindDataProvider.GetFullInvoices());
        }
    }
}
