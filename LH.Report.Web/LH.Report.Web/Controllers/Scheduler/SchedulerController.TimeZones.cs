using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class SchedulerController: DemoController {
        public ActionResult TimeZones(){
            return DemoView("TimeZones", SchedulerDataHelper.DataObject);
        }
        public ActionResult TimeZonesPartial() {
            return PartialView("TimeZonesPartial", SchedulerDataHelper.DataObject);
        }
    }
}
