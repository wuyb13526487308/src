using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.Utils;
using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public partial class PivotGridController: DemoController {
        public ActionResult DrillDown() {
            return DemoView("DrillDown", NorthwindDataProvider.GetCustomerReports());
        }
        public ActionResult DrillDownPivotGridPartial(bool? isResetGridViewPageIndex) {
            return PartialView("DrillDownPivotGridPartial", NorthwindDataProvider.GetCustomerReports());
        }
        public ActionResult DrillDownGridViewPartial(int? rowIndex, int? columnIndex, bool? isResetGridViewPageIndex) {
            object dataObject = rowIndex != null && columnIndex != null
                ? PivotGridExtension.CreateDrillDownDataSource(PivotGridDemoHelper.DrillDownPivotGridSettings, NorthwindDataProvider.GetCustomerReports(), columnIndex.Value, rowIndex.Value)
                : null;
            if (isResetGridViewPageIndex != null)
                ViewBag.IsResetGridViewPageIndex = isResetGridViewPageIndex.Value;
            return PartialView("DrillDownGridViewPartial", dataObject);
        }
    }
}
