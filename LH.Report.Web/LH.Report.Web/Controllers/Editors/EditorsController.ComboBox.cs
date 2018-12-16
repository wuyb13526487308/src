using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class EditorsController : DemoController {
        public ActionResult ComboBox() {
            ViewData["Products"] = NorthwindDataProvider.GetProducts();
            ViewData["Customers"] = NorthwindDataProvider.GetCustomers();
            return DemoView("ComboBox");
        }
        public ActionResult ComboBoxPartial() {
            ViewData["Products"] = NorthwindDataProvider.GetProducts();
            return PartialView();
        }
        public ActionResult MultiColumnComboBoxPartial() {
            ViewData["Customers"] = NorthwindDataProvider.GetCustomers();
            return PartialView();
        }
    }
}
