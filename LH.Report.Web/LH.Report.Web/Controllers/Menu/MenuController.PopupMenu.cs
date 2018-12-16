using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class MenuController: DemoController {
        [HttpGet]
        public ActionResult PopupMenu() {
            ViewData["Options"] = new PopupMenuOptions();
            return DemoView("PopupMenu", PopulationAreaProvider.GetPopulationAreaStructure());
        }
        [HttpPost]
        public ActionResult PopupMenu(PopupMenuOptions options) {
            ViewData["Options"] = options;
            return DemoView("PopupMenu", PopulationAreaProvider.GetPopulationAreaStructure());
        }
        public ActionResult PopupMenuGridViewPartial(string sortColumn) {
            ViewBag.SortColumn = sortColumn;
            return PartialView("PopupMenuGridViewPartial", PopulationAreaProvider.GetPopulationAreaStructure());
        }
    }
}
