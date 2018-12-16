using System.Threading;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        public ActionResult DataBindingToXML() {
            return DemoView("DataBindingToXML");
        }
        public ActionResult DataBindingToXMLPartial() {
            if(DevExpressHelper.IsCallback)
                // Intentionally pauses server-side processing,
                // to demonstrate the Loading Panel functionality.
                Thread.Sleep(500);
            return PartialView("DataBindingToXMLPartial");
        }
    }
}
