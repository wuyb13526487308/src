using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult Export() {
            return DemoView("Export", NorthwindDataProvider.GetInvoices());
        }
        public ActionResult ExportPartial() {
            return PartialView("ExportPartial", NorthwindDataProvider.GetInvoices());
        }
        public ActionResult ExportTo() {
            foreach(string typeName in GridViewDemosHelper.ExportTypes.Keys) {
                if(Request.Params[typeName] != null) {
                    return GridViewDemosHelper.ExportTypes[typeName].Method(GridViewDemosHelper.ExportGridViewSettings, NorthwindDataProvider.GetInvoices());
                }
            }
            return RedirectToAction("Export");
        }
    }
}
