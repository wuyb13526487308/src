using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class EditorsController : DemoController {
        [HttpGet]
        public ActionResult RadioButtonList() {
            ViewData["Options"] = new CheckListDemoOptions();
            return DemoView("RadioButtonList");
        }
        [HttpPost]
        public ActionResult RadioButtonList([Bind]CheckListDemoOptions options) {
            ViewData["Options"] = options;
            return DemoView("RadioButtonList");
        }
    }
}
