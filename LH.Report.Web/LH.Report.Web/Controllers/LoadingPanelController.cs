using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class LoadingPanelController : DemoController {
        public override string Name { get { return "LoadingPanel"; } }

        public ActionResult Index() {
            return Example();
        }
    }
}
