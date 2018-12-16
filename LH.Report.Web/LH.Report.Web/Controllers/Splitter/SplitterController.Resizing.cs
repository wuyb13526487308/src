using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class SplitterController: DemoController {
        public ActionResult Resizing() {
            ViewData["Employees"] = NorthwindDataProvider.GetEmployeesList();
            int employeeID = NorthwindDataProvider.GetFirstEmployeeID();
            return DemoView("Resizing", NorthwindDataProvider.GetOrders(employeeID));
        }
        public ActionResult ResizingPartial() {
            int employeeID = !string.IsNullOrEmpty(Request.Params["EmployeeID"]) ? int.Parse(Request.Params["EmployeeID"]) : NorthwindDataProvider.GetFirstEmployeeID();
            return PartialView("ResizingPartial", NorthwindDataProvider.GetOrders(employeeID));
        }
    }
}
