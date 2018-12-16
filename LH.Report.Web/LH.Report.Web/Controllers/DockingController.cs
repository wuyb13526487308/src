using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class DockingController : DemoController {
        public override string Name { get { return "Docking"; } }  

        public ActionResult Index() {
            return ForbiddenZones();
        }
    }
}
