using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult MasterDetail() {
            return DemoView("MasterDetail", NorthwindDataProvider.GetCustomers());
        }
        public ActionResult MasterDetailMasterPartial() {
            return PartialView("MasterDetailMasterPartial", NorthwindDataProvider.GetCustomers());
        }
        public ActionResult MasterDetailDetailPartial(string customerID) {
            ViewData["CustomerID"] = customerID;
            return PartialView("MasterDetailDetailPartial", NorthwindDataProvider.GetInvoices(customerID));
        }
    }
}
