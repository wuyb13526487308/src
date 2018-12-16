using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class MenuController: DemoController {
        [HttpGet]
        public ActionResult Features() {
            ViewData["Options"] = new MenuFeaturesDemoOptions();
            return DemoView("Features");
        }
        [HttpPost]
        public ActionResult Features([Bind]MenuFeaturesDemoOptions options) {
            if(!ModelState.IsValid) {
                if(!ModelState.IsValidField("AppearAfter"))
                    options.AppearAfter = MenuFeaturesDemoOptions.DefaultAppearAfter;
                if(!ModelState.IsValidField("DisappearAfter"))
                    options.DisappearAfter = MenuFeaturesDemoOptions.DefaultDisappearAfter;
                if(!ModelState.IsValidField("MaximumDisplayLevels"))
                    options.MaximumDisplayLevels = MenuFeaturesDemoOptions.DefaultMaximumDisplayLevels;
            }
            ViewData["Options"] = options;
            return DemoView("Features");
        }
    }
}
