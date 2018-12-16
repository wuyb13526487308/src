using System;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class PivotGridController: DemoController {
        [HttpGet]
        public ActionResult FieldsCustomization() {
            return DemoView("FieldsCustomization", NorthwindDataProvider.GetSalesPerson());
        }
        [HttpPost]
        public ActionResult FieldsCustomization([Bind]PivotGridFieldsCustomizationDemoOptions options) {
            Session["FieldsCustomizationDemoOptions"] = options;
            return DemoView("FieldsCustomization", NorthwindDataProvider.GetSalesPerson());
        }

        public ActionResult FieldsCustomizationPartial() {
            return PartialView("FieldsCustomizationPartial", NorthwindDataProvider.GetSalesPerson());
        }
    }
}
