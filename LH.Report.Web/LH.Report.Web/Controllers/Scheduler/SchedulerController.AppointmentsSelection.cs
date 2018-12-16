using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class SchedulerController: DemoController {
        public ActionResult AppointmentsSelection() {
            return DemoView("AppointmentsSelection", SchedulerDataHelper.DataObject);
        }

        public ActionResult AppointmentsSelectionPartial() {
            return PartialView("AppointmentsSelectionPartial", SchedulerDataHelper.DataObject);
        }

    }
}
