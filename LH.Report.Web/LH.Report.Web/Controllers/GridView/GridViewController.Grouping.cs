using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult Grouping() {
            return DemoView("Grouping", NorthwindDataProvider.GetCustomers());
        }
        public ActionResult GroupingPartial() {
            return PartialView("GroupingPartial", NorthwindDataProvider.GetCustomers());
        }
        public ActionResult CustomGroupingPartial(int param) {
            ViewBag.GroupedColumns = GetGroupedColumns(param);
            return PartialView("GroupingPartial", NorthwindDataProvider.GetCustomers());
        }
        static string GetGroupedColumns(int param) {
            switch (param) {
                case 0:
                    return "Country";
                case 1:
                    return "Country;City";
                case 2:
                    return "CompanyName";
            }
            return null;
        }
    }
}
