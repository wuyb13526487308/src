using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class NavBarController: DemoController {
        public ActionResult DataBindingToXML() {
            ViewData["XPath"] = "/Cameras/*";
            return DemoView("DataBindingToXML", true);
        }
        public ActionResult DataBindingToXMLPartial() {
            ViewData["XPath"] = Request.Params["cmbFilter"];
            return PartialView();
        }
    }
}
