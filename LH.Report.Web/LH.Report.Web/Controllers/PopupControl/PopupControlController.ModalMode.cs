using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class PopupControlController: DemoController {
        public ActionResult ModalMode() {
            return DemoView("ModalMode");
        }
    }
}
