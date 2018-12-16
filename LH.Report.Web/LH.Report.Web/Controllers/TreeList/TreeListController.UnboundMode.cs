using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        public ActionResult UnboundMode() {
            return DemoView("UnboundMode");
        }
        public ActionResult UnboundModePartial() {
            if(DevExpressHelper.IsCallback)
                // Intentionally pauses server-side processing,
                // to demonstrate the Loading Panel functionality.
                Thread.Sleep(500);
            return PartialView("UnboundModePartial");
        }
    }
}
