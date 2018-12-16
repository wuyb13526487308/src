using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class PopupControlController: DemoController {
        public ActionResult DataBinding() {
            return DemoView("DataBinding", new CategoriesData());
        }
    }
}
