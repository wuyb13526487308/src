using System;
using System.Web.Mvc;
using System.Web;
using System.Collections;

namespace DevExpress.Web.Demos {
    [HandleError]
    public class HomeController : DemoController {
        public override string Name {
            get {
                return "Home";
            }
        }

        public ActionResult Index() {
            return DemoView("Index");
        }
        public ActionResult CodePartialPartial() {
            return PartialView("CodePartialPartial");
        }
    }
}
