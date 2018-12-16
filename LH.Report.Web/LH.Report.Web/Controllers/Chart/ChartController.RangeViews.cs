using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        [HttpGet]
        public ActionResult RangeViews() {
            ChartViewTypeDemoOptions options = new ChartViewTypeDemoOptions();
            options.View = DevExpress.XtraCharts.ViewType.RangeBar;
            ViewData[ChartDemoHelper.OptionsKey] = options;
            return DemoView("RangeViews", OilPricesProvider.GetOilPrices());
        }
        [HttpPost]
        public ActionResult RangeViews([Bind] ChartViewTypeDemoOptions options) {
            ViewData[ChartDemoHelper.OptionsKey] = options;
            return DemoView("RangeViews", OilPricesProvider.GetOilPrices());
        }
    }
}
