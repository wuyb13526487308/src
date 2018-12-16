using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System;
using DevExpress.Web.ASPxEditors;

namespace DevExpress.Web.Demos {
    public partial class CommonController: DemoController {
        public ActionResult AjaxActionLink() {
            return DemoView("AjaxActionLink", NorthwindDataProvider.GetProducts());
        }
        public ActionResult AjaxActionLinkPartial() {
            return PartialView("AjaxActionLinkPartial", NorthwindDataProvider.GetProducts());
        }
        public ActionResult AjaxActionLinkCategoryPartial(int categoryID) {
            return PartialView("AjaxActionLinkCategoryPartial", NorthwindDataProvider.GetCategoryByID(categoryID));
        }
    }
}
