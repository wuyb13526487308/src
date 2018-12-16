using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        [HttpGet]
        public ActionResult BarViews() {
            ChartBarViewsDemoOptions options = new ChartBarViewsDemoOptions();
            options.View = DevExpress.XtraCharts.ViewType.Bar;
            ViewData[ChartDemoHelper.OptionsKey] = options;
            return DemoView("BarViews", GreatLakesStateProductProvider.GetGreatLakesStateProduct());
        }
        [HttpPost]
        public ActionResult BarViews([Bind]ChartBarViewsDemoOptions options) {
            ViewData[ChartDemoHelper.OptionsKey] = options;
            object model;
            if(ChartDemoHelper.IsSideBySideStackedView(options.View))
                model = PopulationAgeProvider.GetPopulationAgeStructure();
            else
                model = GreatLakesStateProductProvider.GetGreatLakesStateProduct();
            return DemoView("BarViews", model);
        }
        public ActionResult BarViewsPartial() {
            return PartialView("BarViewsPartial");
        }
        public ActionResult BarViewsSideBySideStackedPartial() {
            return PartialView("BarViewsSideBySideStackedPartial");
        }
    }
}
