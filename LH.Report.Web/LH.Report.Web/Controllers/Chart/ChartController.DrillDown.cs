using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ChartController : DemoController {
        public ActionResult DrillDown(string category) {
            object model;
            ViewData[ChartDemoHelper.CategoryKey] = category;
            if(string.IsNullOrEmpty(category))
                model = NorthwindDataProvider.GetCategoriesAverage();
            else {
                model = NorthwindDataProvider.GetProducts(category);
            }
            return DemoView("DrillDown", model);
        }
        public ActionResult DrillDownPartial(string category) {
            ViewData[ChartDemoHelper.CategoryKey] = category;
            if(string.IsNullOrEmpty(category))
                return PartialView("DrillDownPartial", NorthwindDataProvider.GetCategoriesAverage());
            else {
                return PartialView("DrillDownCategoryPartial", NorthwindDataProvider.GetProducts(category));
            }
        }
    }
}
