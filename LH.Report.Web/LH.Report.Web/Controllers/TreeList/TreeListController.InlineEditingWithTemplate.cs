using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        public ActionResult InlineEditingWithTemplate() {
            return DemoView("InlineEditingWithTemplate", NewsGroupsProvider.GetEditablePosts());
        }
        [ValidateInput(false)]
        public ActionResult InlineEditingWithTemplatePartial() {
            return PartialView("InlineEditingWithTemplatePartial", NewsGroupsProvider.GetEditablePosts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingWithTemplateAddNewPostPartial(EditablePost post) {
            if(ModelState.IsValid) {
                try {
                    NewsGroupsProvider.InsertPost(post);
                }
                catch(Exception e) {
                    ViewData["EditNodeError"] = e.Message;
                }
            }
            else
                ViewData["EditNodeError"] = "Please, correct all errors.";
            return PartialView("InlineEditingWithTemplatePartial", NewsGroupsProvider.GetEditablePosts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingWithTemplateUpdatePostPartial(EditablePost post) {
            if(ModelState.IsValid) {
                try {
                    NewsGroupsProvider.UpdatePost(post);
                }
                catch(Exception e) {
                    ViewData["EditNodeError"] = e.Message;
                }
            }
            else
                ViewData["EditNodeError"] = "Please, correct all errors.";
            return PartialView("InlineEditingWithTemplatePartial", NewsGroupsProvider.GetEditablePosts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingWithTemplateMovePostPartial(int postID, int? parentID) {
            NewsGroupsProvider.MovePost(postID, parentID);
            return PartialView("InlineEditingWithTemplatePartial", NewsGroupsProvider.GetEditablePosts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingWithTemplateDeletePostPartial(int postID) {
            try {
                NewsGroupsProvider.DeletePost(postID);
            }
            catch(Exception e) {
                ViewData["EditNodeError"] = e.Message;
            }
            return PartialView("InlineEditingWithTemplatePartial", NewsGroupsProvider.GetEditablePosts());
        }
    }
}
