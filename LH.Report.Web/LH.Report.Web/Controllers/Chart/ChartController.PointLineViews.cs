using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        [HttpGet]
        public ActionResult PointLineViews() {
            ChartBarViewsDemoOptions options = new ChartBarViewsDemoOptions();
            options.ShowLabels = true;
            options.View = DevExpress.XtraCharts.ViewType.Point;
            ViewData[ChartDemoHelper.OptionsKey] = options;
            return DemoView("PointLineViews", CorporationsMarketValueProvider.GetCorporationsMarketValue());
        }
        [HttpPost]
        public ActionResult PointLineViews([Bind] ChartBarViewsDemoOptions options) {
            ViewData[ChartDemoHelper.OptionsKey] = options;
            object data;
            switch(options.View) {
                case DevExpress.XtraCharts.ViewType.Bubble:
                    data = MoviesProvider.GetMovies();
                    break;
                case DevExpress.XtraCharts.ViewType.ScatterLine:
                    data = MathematicsFunctions.GetArchimedianSpiralPoints();
                    break;
                case DevExpress.XtraCharts.ViewType.FullStackedLine:
                case DevExpress.XtraCharts.ViewType.FullStackedLine3D:
                    data = ArchitectureProvider.GetArchitecturesValues();
                    break;
                case DevExpress.XtraCharts.ViewType.StackedLine:
                case DevExpress.XtraCharts.ViewType.StackedLine3D:
                    data = GreatLakesStateProductProvider.GetGreatLakesStateProduct();
                    break;
                default:
                    data = CorporationsMarketValueProvider.GetCorporationsMarketValue();
                    break;
            }
            return DemoView("PointLineViews", data);
        }
        public ActionResult PointLineViewsPartial() {
            return PartialView("PointLineViewsPartial");
        }
        public ActionResult PointLineViewsBubblePartial() {
            return PartialView("PointLineViewsBubblePartial");
        }
        public ActionResult PointLineViewsScatterLinePartial() {
            return PartialView("PointLineViewsScatterLinePartial");
        }
        public ActionResult PointLineViewsStackedLinePartial() {
            return PartialView("PointLineViewsStackedLinePartial");
        }
        public ActionResult PointLineViewsFullStackedLinePartial() {
            return PartialView("PointLineViewsFullStackedLinePartial");
        }
    }
}
