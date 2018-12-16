using DevExpress.Web.Demos;
using System.Web.Mvc;
using System.Threading;

namespace DevExpress.Web.Demos {
    public partial class PopupControlController : DemoController {
        public ActionResult LoadOnDemand() {
            return DemoView("LoadOnDemand");
        }
        public ActionResult LoadOnDemandPartial() {
            // Intentionally pauses server-side processing, 
            // to demonstrate the Loading Panel functionality.
            Thread.Sleep(1000); 
            return PartialView("LoadOnDemandPartial");
        }
    }
}
