using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class SchedulerController: DemoController {
        public ActionResult Templates() {
            return DemoView("Templates", SchedulerDataHelper.DataObject);
        }
        public ActionResult TemplatesPartial() {
            return PartialView("TemplatesPartial", SchedulerDataHelper.DataObject);
        }
    }
}
