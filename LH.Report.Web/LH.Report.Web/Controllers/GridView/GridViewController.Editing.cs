using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult Editing() {
            return DemoView("Editing", NorthwindDataProvider.GetEditableProducts());
        }
        public ActionResult EditingPartial() {
            return PartialView("EditingPartial", NorthwindDataProvider.GetEditableProducts());
        }
        [HttpGet]
        public ActionResult EditingEdit(int productID) {
            EditableProduct editProduct = NorthwindDataProvider.GetEditableProduct(productID);
            if(editProduct == null) {
                editProduct = new EditableProduct();
                editProduct.ProductID = -1;
            }
            return DemoView("Editing", "EditingForm", editProduct);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult EditingEdit(EditableProduct product) {
            if (!ModelState.IsValid)
                return DemoView("Editing", "EditingForm", product);

            if (product.ProductID == -1)
                NorthwindDataProvider.InsertProduct(product);
            else
                NorthwindDataProvider.UpdateProduct(product);
            return RedirectToAction("Editing");
        }
        public ActionResult EditingDelete(int productID) {
            NorthwindDataProvider.DeleteProduct(productID);
            return RedirectToAction("Editing");
        }
    }
}
