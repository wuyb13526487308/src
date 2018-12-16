using System.Threading;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class DataViewController : DemoController {
        public ActionResult DataBinding() {
            return DemoView("DataBinding");
        }
        public ActionResult DataBindingPartial() {
            if(DevExpressHelper.IsCallback)
                // Intentionally pauses server-side processing,
                // to demonstrate the Loading Panel functionality.
                Thread.Sleep(500);
            return PartialView("DataBindingPartial");
        }
    }
}
