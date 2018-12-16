using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        [HttpGet]
        public ActionResult SeriesBinding() {
            ChartSeriesBindingDemoOptions options = new ChartSeriesBindingDemoOptions();
            string category = string.IsNullOrEmpty(options.Category) ? ChartSeriesBindingDemoOptions.DefaultCategory : options.Category;
            ViewData[ChartDemoHelper.OptionsKey] = options;
            return DemoView("SeriesBinding", NorthwindDataProvider.GetProducts(category));
        }
        [HttpPost]
        public ActionResult SeriesBinding([Bind] ChartSeriesBindingDemoOptions options) {
            string category = string.IsNullOrEmpty(options.Category) ? ChartSeriesBindingDemoOptions.DefaultCategory : options.Category;
            ViewData[ChartDemoHelper.OptionsKey] = options;
            return DemoView("SeriesBinding", NorthwindDataProvider.GetProducts(category));
        }
    }
}
