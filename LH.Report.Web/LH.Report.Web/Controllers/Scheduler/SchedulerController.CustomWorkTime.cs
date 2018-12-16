using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.XtraScheduler;

namespace DevExpress.Web.Demos {
    public partial class SchedulerController: DemoController {
        public ActionResult CustomWorkTime() {
            ViewData["isCustomWorkTimeEnabled"] = false;
            return DemoView("CustomWorkTime", SchedulerDataHelper.DataObject);
        }
        public ActionResult CustomWorkTimePartial(bool isCustomWorkTimeEnabled) {
            ViewData["isCustomWorkTimeEnabled"] = isCustomWorkTimeEnabled;
            return PartialView("CustomWorkTimePartial", SchedulerDataHelper.DataObject);
        }
    }
}
