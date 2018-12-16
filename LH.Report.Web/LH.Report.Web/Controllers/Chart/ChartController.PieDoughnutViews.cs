using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        [HttpGet]
        public ActionResult PieDoughnutViews() {
            ViewData[ChartDemoHelper.OptionsKey] = new ChartPieDoughnutViewsDemoOptions();
            return DemoView("PieDoughnutViews", CountriesProvider.GetCountries());
        }
        [HttpPost]
        public ActionResult PieDoughnutViews([Bind] ChartPieDoughnutViewsDemoOptions options) {
            ViewData[ChartDemoHelper.OptionsKey] = options;
            return DemoView("PieDoughnutViews", CountriesProvider.GetCountries());
        }
    }
}
