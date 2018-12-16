using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class CommonController: DemoController {
        public ActionResult Callbacks() {
            return DemoView("Callbacks");
        }
        public ActionResult CallbacksPartial(string selectedMenuItemName) {
            string actionName = string.Format("Callbacks{0}Partial", selectedMenuItemName);
            object model = null;
            if (selectedMenuItemName == "DataMining")
                model = NorthwindDataProvider.GetCustomerReports();
            else if (selectedMenuItemName == "Visualization")
                model = NorthwindDataProvider.GetProducts(ChartSeriesBindingDemoOptions.DefaultCategory);
            return PartialView(actionName, model);
        }
        public ActionResult CallbacksDataMiningPartial() {
            return PartialView("CallbacksDataMiningPartial", NorthwindDataProvider.GetCustomerReports());
        }
    }
}
