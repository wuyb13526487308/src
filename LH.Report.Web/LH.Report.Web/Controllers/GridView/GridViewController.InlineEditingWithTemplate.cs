using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public ActionResult InlineEditingWithTemplate() {
            return DemoView("InlineEditingWithTemplate", NorthwindDataProvider.GetEditableProducts());
        }
        [ValidateInput(false)]
        public ActionResult InlineEditingWithTemplatePartial() {
            return PartialView("InlineEditingWithTemplatePartial", NorthwindDataProvider.GetEditableProducts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingWithTemplateAddNewPartial(EditableProduct product) {
            if(ModelState.IsValid) {
                try {
                    NorthwindDataProvider.InsertProduct(product);
                }
                catch(Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else {
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["EditableProduct"] = product;
            }
            return PartialView("InlineEditingWithTemplatePartial", NorthwindDataProvider.GetEditableProducts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingWithTemplateUpdatePartial(EditableProduct product) {
            if(ModelState.IsValid) {
                try {
                    NorthwindDataProvider.UpdateProduct(product);
                }
                catch(Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            else {
                ViewData["EditError"] = "Please, correct all errors.";
                ViewData["EditableProduct"] = product;
            }

            return PartialView("InlineEditingWithTemplatePartial", NorthwindDataProvider.GetEditableProducts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingWithTemplateDeletePartial(int productID) {
            if(productID > 0) {
                try {
                    NorthwindDataProvider.DeleteProduct(productID);
                }
                catch(Exception e) {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("InlineEditingWithTemplatePartial", NorthwindDataProvider.GetEditableProducts());
        }
    }
}
