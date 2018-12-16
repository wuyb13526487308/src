using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        [HttpGet]
        public ActionResult FinancialViews() {
            ViewData[ChartDemoHelper.OptionsKey] = new ChartFinacialViewsDemoOptions();
            return DemoView("FinancialViews", DellStockPricesProvider.GetDellStockPrices());
        }
        [HttpPost]
        public ActionResult FinancialViews([Bind] ChartFinacialViewsDemoOptions options) {
            ViewData[ChartDemoHelper.OptionsKey] = options;
            return DemoView("FinancialViews", DellStockPricesProvider.GetDellStockPrices());
        }
    }
}
