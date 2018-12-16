using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        [HttpGet]
        public ActionResult FunnelViews() {
            ViewData[ChartDemoHelper.OptionsKey] = new ChartFunnelViewsDemoOptions();
            return DemoView("FunnelViews", WebSiteVisitorsProvider.GetWebSiteVisitors());
        }
        [HttpPost]
        public ActionResult FunnelViews([Bind] ChartFunnelViewsDemoOptions options) {
            ViewData[ChartDemoHelper.OptionsKey] = options;
            return DemoView("FunnelViews", WebSiteVisitorsProvider.GetWebSiteVisitors());
        }
    }
}
