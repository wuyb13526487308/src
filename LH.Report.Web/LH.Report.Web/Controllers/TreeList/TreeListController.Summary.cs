using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        public ActionResult Summary() {
            return DemoView("Summary", DepartmentsProvider.GetDepartments());
        }
        public ActionResult SummaryPartial() {
            return PartialView("SummaryPartial", DepartmentsProvider.GetDepartments());
        }
    }
}
