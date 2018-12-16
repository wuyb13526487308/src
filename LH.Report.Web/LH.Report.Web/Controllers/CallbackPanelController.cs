using System.Web.Mvc;
using System.Web.UI;

namespace DevExpress.Web.Demos {
    public partial class CallbackPanelController : DemoController {
        public override string Name { get { return "CallbackPanel"; } }

        public ActionResult Index() {
            return Example();
        }
    }
}
