using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.XtraScheduler;

namespace DevExpress.Web.Demos {
    public partial class SchedulerController: DemoController {
        public ActionResult Grouping() {
            Session["GroupType"] = SchedulerGroupType.Date;
            return DemoView("Grouping", SchedulerDataHelper.DataObject);
        }
        [HttpPost]
        public ActionResult Grouping(SchedulerGroupType GroupType) {
            Session["GroupType"] = GroupType;
            return DemoView("Grouping", SchedulerDataHelper.DataObject);
        }
        public ActionResult GroupingPartial() {
            return PartialView("GroupingPartial", SchedulerDataHelper.DataObject);
        }
    }
}
