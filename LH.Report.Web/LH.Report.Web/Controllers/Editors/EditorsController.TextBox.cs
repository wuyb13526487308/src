using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class EditorsController : DemoController {
        public ActionResult TextBox() {
            return DemoView("TextBox");
        }
    }
}
