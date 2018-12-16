using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        [HttpGet]
        public ActionResult MultipleNodeSelection() {
            TreeListMultipleSelectionDemoOptions options = new TreeListMultipleSelectionDemoOptions();
            options.EnableRecursiveSelection = false;
            options.AllowSelectAll = false;
            options.SelectMode = "All";
            Session["SelectionOptions"] = options;
            return DemoView("MultipleNodeSelection", DepartmentsProvider.GetDepartments());
        }
        [HttpPost]
        public ActionResult MultipleNodeSelection([Bind] TreeListMultipleSelectionDemoOptions options) {
            Session["SelectionOptions"] = options;
            return DemoView("MultipleNodeSelection", DepartmentsProvider.GetDepartments());
        }
        public ActionResult MultipleNodeSelectionPartial() {
            return PartialView("MultipleNodeSelectionPartial", DepartmentsProvider.GetDepartments());
        }
    }
}
