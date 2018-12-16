using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        [HttpGet]
        public ActionResult RadarPolarViews() {
            ViewData[ChartDemoHelper.OptionsKey] = new ChartRadarPolarViewsDemoOptions();
            return DemoView("RadarPolarViews", WeatherInLondon.GetTemperatureHistory());
        }
        [HttpPost]
        public ActionResult RadarPolarViews([Bind] ChartRadarPolarViewsDemoOptions options) {
            ViewData[ChartDemoHelper.OptionsKey] = options;
            object model;
            if(ChartDemoHelper.IsPolarView(options.View))
                model = MathematicsFunctions.GetLemniscatePoints();
            else
                model = WeatherInLondon.GetTemperatureHistory();
            return DemoView("RadarPolarViews", model);
        }
        public ActionResult RadarPolarViewsPolarPartial() {
            return PartialView("RadarPolarViewsPolarPartial");
        }
        public ActionResult RadarPolarViewsRadarPartial() {
            return PartialView("RadarPolarViewsRadarPartial");
        }
    }
}
