using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult InlineEditing() {
            return DemoView("InlineEditing", NorthwindDataProvider.GetEditableProducts());
        }
        [ValidateInput(false)]
        public ActionResult InlineEditingPartial() {
            return PartialView("InlineEditingPartial", NorthwindDataProvider.GetEditableProducts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingAddNewPartial(EditableProduct product) {
            if(ModelState.IsValid) {
                try {
                    NorthwindDataProvider.InsertProduct(product);
                }
                catch(Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("InlineEditingPartial", NorthwindDataProvider.GetEditableProducts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingUpdatePartial(EditableProduct product) {
            if(ModelState.IsValid) {
                try {
                    NorthwindDataProvider.UpdateProduct(product);
                }
                catch(Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";

            return PartialView("InlineEditingPartial", NorthwindDataProvider.GetEditableProducts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingDeletePartial(int productID) {
            if(productID >= 0) {
                try {
                    NorthwindDataProvider.DeleteProduct(productID);
                }
                catch(Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("InlineEditingPartial", NorthwindDataProvider.GetEditableProducts());
        }
    }
}
