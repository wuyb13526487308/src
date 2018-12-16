using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        [HttpGet]
        public ActionResult AreaViews() {
            ChartShowLabelsDemoOptions options = new ChartShowLabelsDemoOptions();
            options.ShowLabels = true;
            options.View = DevExpress.XtraCharts.ViewType.Area;
            ViewData[ChartDemoHelper.OptionsKey] = options;
            return DemoView("AreaViews", CorporationsMarketValueProvider.GetCorporationsMarketValue());
        }
        [HttpPost]
        public ActionResult AreaViews([Bind] ChartShowLabelsDemoOptions options) {
            ViewData[ChartDemoHelper.OptionsKey] = options;
            object data;
            switch(options.View) {
                case DevExpress.XtraCharts.ViewType.FullStackedArea:
                case DevExpress.XtraCharts.ViewType.FullStackedArea3D:
                case DevExpress.XtraCharts.ViewType.FullStackedSplineArea:
                case DevExpress.XtraCharts.ViewType.FullStackedSplineArea3D:
                    data = ArchitectureProvider.GetArchitecturesValues();
                    break;
                case DevExpress.XtraCharts.ViewType.StackedArea:
                case DevExpress.XtraCharts.ViewType.StackedArea3D:
                case DevExpress.XtraCharts.ViewType.StackedSplineArea:
                case DevExpress.XtraCharts.ViewType.StackedSplineArea3D:
                    data = GreatLakesStateProductProvider.GetGreatLakesStateProduct();
                    break;
                default:
                    data = CorporationsMarketValueProvider.GetCorporationsMarketValue();
                    break;
            }
            return DemoView("AreaViews", data);
        }
        public ActionResult AreaViewsFullStackedPartial() {
            return PartialView("AreaViewsFullStackedPartial");
        }
        public ActionResult AreaViewsStackedPartial() {
            return PartialView("AreaViewsStackedPartial");
        }
        public ActionResult AreaViewsPartial() {
            return PartialView("AreaViewsPartial");
        }
    }
}
