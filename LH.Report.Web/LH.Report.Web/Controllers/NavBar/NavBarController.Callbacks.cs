using System.Threading;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class NavBarController: DemoController {
        public ActionResult Callbacks() {
            return DemoView("Callbacks");
        }
        public ActionResult CallbacksPartial() {
            if(DevExpressHelper.IsCallback) 
                Thread.Sleep(1000);
            return PartialView("CallbacksPartial");
        }
    }
}
