using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        public ActionResult InlineEditing() {
            return DemoView("InlineEditing", NewsGroupsProvider.GetEditablePosts());
        }
        [ValidateInput(false)]
        public ActionResult InlineEditingPartial() {
            return PartialView("InlineEditingPartial", NewsGroupsProvider.GetEditablePosts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingAddNewPostPartial(EditablePost post) {
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
            return PartialView("InlineEditingPartial", NewsGroupsProvider.GetEditablePosts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingUpdatePostPartial(EditablePost post) {
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
            return PartialView("InlineEditingPartial", NewsGroupsProvider.GetEditablePosts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingMovePostPartial(int postID, int? parentID) {
            NewsGroupsProvider.MovePost(postID, parentID);
            return PartialView("InlineEditingPartial", NewsGroupsProvider.GetEditablePosts());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult InlineEditingDeletePostPartial(int postID) {
            try {
                NewsGroupsProvider.DeletePost(postID);
            }
            catch(Exception e) {
                ViewData["EditNodeError"] = e.Message;
            }
            return PartialView("InlineEditingPartial", NewsGroupsProvider.GetEditablePosts());
        }
    }
}
