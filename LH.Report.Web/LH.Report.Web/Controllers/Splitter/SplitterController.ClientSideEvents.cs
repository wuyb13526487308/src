using System;
using System.Collections;
using System.Data.Linq;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class SplitterController: DemoController {
        public ActionResult ClientSideEvents() {
            return ClientSideEventsDemoView(new string[]{
                "Init",
                "PaneResizing",
                "PaneResized",
                "PaneCollapsing",
                "PaneCollapsed",
                "PaneExpanding",
                "PaneExpanded",
            });
        }
        public ActionResult SamplePage1() {
            return View();
        }
        public ActionResult SamplePage2() {
            return View();
        }
        public ActionResult SamplePage3() {
            return View();
        }
    }
}
