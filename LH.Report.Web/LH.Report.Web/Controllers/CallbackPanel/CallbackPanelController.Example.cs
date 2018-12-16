using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Threading;

namespace DevExpress.Web.Demos {
    public partial class CallbackPanelController : DemoController {
        public ActionResult Example() {
            ViewData["Employees"] = NorthwindDataProvider.GetEmployeesList();
            int employeeID = NorthwindDataProvider.GetFirstEmployeeID();
            return DemoView("Example", NorthwindDataProvider.GetEmployee(employeeID));
        }
        public ActionResult ExamplePartial() {
            if(DevExpressHelper.IsCallback)
                // Intentionally pauses server-side processing,
                // to demonstrate the Loading Panel functionality.
                Thread.Sleep(500);
            int employeeID = !string.IsNullOrEmpty(Request.Params["EmployeeID"]) ? int.Parse(Request.Params["EmployeeID"]) : NorthwindDataProvider.GetFirstEmployeeID();
            return PartialView("ExamplePartial", NorthwindDataProvider.GetEmployee(employeeID));
        }
    }
}
