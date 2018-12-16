using System;
using System.Threading;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class DataViewController : DemoController {
        public ActionResult CustomCallback() {
            Session["SortCommand"] = String.Empty;
            return DemoView("CustomCallback", Cameras.GetData());
        }
        public ActionResult CustomCallbackPartial() {
            // Intentionally pauses server-side processing,
            // to demonstrate the Loading Panel functionality.
            Thread.Sleep(500);
            return PartialView("CustomCallbackPartial", Cameras.GetData((string)Session["SortCommand"]));
        }
        public ActionResult SortData(string sortCommand) {
            // Intentionally pauses server-side processing,
            // to demonstrate the Loading Panel functionality.
            Thread.Sleep(500);
            Session["SortCommand"] = sortCommand;
            return PartialView("CustomCallbackPartial", Cameras.GetData(sortCommand));
        }
    }
}
