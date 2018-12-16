using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.Utils;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public partial class PivotGridController: DemoController {
        public ActionResult Export() {
            Session["ExportOptions"] = new PivotGridExportDemoOptions();
            return DemoView("Export", NorthwindDataProvider.GetCustomerReports());
        }
        public ActionResult ExportPartial() {
            return PartialView("ExportPartial", NorthwindDataProvider.GetCustomerReports());
        }
        public ActionResult ExportTo([Bind]PivotGridExportDemoOptions options) {
            return PivotGridDemoHelper.ExportTypes[options.ExportType].Method(PivotGridDemoHelper.GetPivotGridExportSettings(options), NorthwindDataProvider.GetCustomerReports());
        }
    }
}
