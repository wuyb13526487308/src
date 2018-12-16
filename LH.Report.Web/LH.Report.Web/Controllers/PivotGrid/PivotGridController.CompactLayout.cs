using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.XtraPivotGrid;
using DevExpress.XtraPivotGrid.Customization;
using System.Web.UI.WebControls;
using DevExpress.Utils;

namespace DevExpress.Web.Demos {
    public partial class PivotGridController: DemoController {
        public ActionResult CompactLayout() {
            return DemoView("CompactLayout", NorthwindDataProvider.GetSalesPerson());
        }
        public ActionResult CompactLayoutPartial() {
            return PartialView("CompactLayoutPartial", NorthwindDataProvider.GetSalesPerson());
        }

    }
}
