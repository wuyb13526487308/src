using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        public ActionResult ConditionalFormatting() {
            return DemoView("ConditionalFormatting", DepartmentsProvider.GetDepartments());
        }
        public ActionResult ConditionalFormattingPartial() {
            return PartialView("ConditionalFormattingPartial", DepartmentsProvider.GetDepartments());
        }
    }
}
