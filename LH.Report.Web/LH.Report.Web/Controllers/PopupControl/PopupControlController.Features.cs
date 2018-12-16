using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class PopupControlController : DemoController {
        [HttpGet]
        public ActionResult Features() {
            ViewData["Options"] = new PopupControlFeaturesDemoOptions();
            return DemoView("Features");
        }
        [HttpPost]
        public ActionResult Features([Bind]PopupControlFeaturesDemoOptions options) {
            if(!ModelState.IsValid) {
                if(!ModelState.IsValidField("Opacity"))
                    options.Opacity = PopupControlFeaturesDemoOptions.DefaultOpacity;
                if(!ModelState.IsValidField("AppearAfter"))
                    options.AppearAfter = PopupControlFeaturesDemoOptions.DefaultAppearAfter;
                if(!ModelState.IsValidField("DisappearAfter"))
                    options.DisappearAfter = PopupControlFeaturesDemoOptions.DefaultDisappearAfter;
            }
            ViewData["Options"] = options;
            return DemoView("Features");
        }
    }
}
