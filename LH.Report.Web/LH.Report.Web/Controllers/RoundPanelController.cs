using System.Web.Mvc;
using DevExpress.Web.ASPxRoundPanel;

namespace DevExpress.Web.Demos {
    public partial class RoundPanelController: DemoController {
        public override string Name { get { return "RoundPanel"; } }

        public ActionResult Index() {
            return Features();
        }
    }

    public class RoundPanelFeaturesDemoOptions {
        public RoundPanelFeaturesDemoOptions() {
            ShowHeader = true;
            View = View.Standard;
        }

        public bool ShowHeader { get; set; }
        public View View { get; set; }
    }
}
