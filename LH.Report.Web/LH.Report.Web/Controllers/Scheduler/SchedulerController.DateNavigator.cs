using System.Web.Mvc;
using DevExpress.XtraScheduler;

namespace DevExpress.Web.Demos {
    public partial class SchedulerController: DemoController {
        public ActionResult DateNavigator() {
            return DemoView("DateNavigator", SchedulerDataHelper.DataObject);
        }
        public ActionResult DateNavigatorPartial() {
            return PartialView("DateNavigatorPartial", SchedulerDataHelper.DataObject);
        }
    }
}
