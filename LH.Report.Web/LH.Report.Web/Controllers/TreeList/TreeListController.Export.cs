using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        [HttpGet]
        public ActionResult Export() {
            TreeListExportDemoOptions options = new TreeListExportDemoOptions() {
                EnableAutoWidth = false,
                ExpandAllNodes = false,
                ShowTreeButtons = false
            };
            Session["TreeListExportOptions"] = options;
            return DemoView("Export", DepartmentsProvider.GetDepartments());
        }
        [HttpPost]
        public ActionResult Export([Bind] TreeListExportDemoOptions options) {
            Session["TreeListExportOptions"] = options;
            foreach(string typeName in TreeListDemoHelper.ExportTypes.Keys) {
                if(Request.Params[typeName] != null) {
                    return TreeListDemoHelper.ExportTypes[typeName].Method(
                        TreeListDemoHelper.CreateExportTreeListSettings(options), 
                        DepartmentsProvider.GetDepartments()
                    );
                }
            }
            return DemoView("Export", DepartmentsProvider.GetDepartments());
        }
        public ActionResult ExportPartial() {
            return PartialView("ExportPartial", DepartmentsProvider.GetDepartments());
        }
    }
}
