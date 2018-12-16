using System.Collections.Generic;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class DataViewController : DemoController {
        public override string Name { get { return "DataView"; } }

        public ActionResult Index() {
            return DataBinding();
        }
    }

    public class DataViewDemoHelper {
        public static List<SelectListItem> GetSortFields() {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = "(none)", Value = "", Selected = true },
                new SelectListItem() { Text = "Model", Value = "Model" },
                new SelectListItem() { Text = "Pixels", Value = "Pixels" }
            };
        }
        public static List<SelectListItem> GetSortOrders() {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = "Ascending", Value = "", Selected = true },
                new SelectListItem() { Text = "Descending", Value = "DESC" }
            };
        }
    }
}
