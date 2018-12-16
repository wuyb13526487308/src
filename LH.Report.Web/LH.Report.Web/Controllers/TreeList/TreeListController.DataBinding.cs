using System.Threading;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        [HttpGet]
        public ActionResult DataBinding() {
            Session["TreeListState"] = null;
            Session["ShowServiceColumns"] = false;
            return DemoView("DataBinding", DepartmentsProvider.GetDepartments());
        }
        [HttpPost]
        public ActionResult DataBinding(bool showServiceColumns) {
            Session["ShowServiceColumns"] = showServiceColumns;
            return DemoView("DataBinding", DepartmentsProvider.GetDepartments());
        }
        public ActionResult DataBindingPartial() {
            if(DevExpressHelper.IsCallback)
                // Intentionally pauses server-side processing,
                // to demonstrate the Loading Panel functionality.
                Thread.Sleep(500);
            return PartialView("DataBindingPartial", DepartmentsProvider.GetDepartments());
        }
    }
}
