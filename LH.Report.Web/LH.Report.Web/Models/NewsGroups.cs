using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using DevExpress.Web.Demos.Models;

namespace DevExpress.Web.Demos {
    public static class NewsGroupsProvider {
        const string NewsGroupsDataContextKey = "DXNewsGroupsDataContext";

        public static NewsGroupsDataContext DB {
            get {
                if(HttpContext.Current.Items[NewsGroupsDataContextKey] == null)
                    HttpContext.Current.Items[NewsGroupsDataContextKey] = new NewsGroupsDataContext();
                return (NewsGroupsDataContext)HttpContext.Current.Items[NewsGroupsDataContextKey];
            }
        }

        public static IEnumerable GetPosts() {
            return from post in DB.Threads select post;
        }
        public static Thread GetPostByID(int id) {
            return (from post in DB.Threads where post.ID == id select post).SingleOrDefault();
        }
        public static IEnumerable GetChildPosts(int id) {
            return from post in DB.Threads where post.ParentID == id select post;
        }

        public static List<EditablePost> GetEditablePosts() {
            List<EditablePost> posts = (List<EditablePost>)HttpContext.Current.Session["Posts"];
            if(posts == null) {
                posts = (from post in DB.Threads
                           select new EditablePost {
                               PostID = post.ID,
                               ParentID = post.ParentID,
                               Subject = post.Subject,
                               From = post.From,
                               Text = post.Text,
                               PostDate = post.Date,
                               IsNew = post.IsNew,
                               HasAttachment = post.HasAttachment
                           }).ToList();
                HttpContext.Current.Session["Posts"] = posts;
            }
            return posts;
        }
        public static List<EditablePost> GetEditableChildPosts(int parentID) {
            return (from post in GetEditablePosts() where post.ParentID == parentID select post).ToList();
        }
        public static EditablePost GetEditablePost(int postID) {
            return (from post in GetEditablePosts() where post.PostID == postID select post).FirstOrDefault();
        }
        public static int GetNewEditablePostID() {
            IEnumerable<EditablePost> editablePosts = GetEditablePosts();
            return (editablePosts.Count() > 0) ? editablePosts.Last().PostID + 1 : 0;
        }

        public static void InsertPost(EditablePost newPost) {
            newPost.PostID = GetNewEditablePostID();
            GetEditablePosts().Add(newPost);
        }
        public static void UpdatePost(EditablePost post) {
            EditablePost postToUpdate = GetEditablePost(post.PostID);
            if(postToUpdate != null) {
                postToUpdate.Subject = post.Subject;
                postToUpdate.From = post.From;
                postToUpdate.PostDate = post.PostDate;
                postToUpdate.Text = post.Text;
                postToUpdate.IsNew = post.IsNew;
                postToUpdate.HasAttachment = post.HasAttachment;
            }
        }
        public static void DeletePost(int id) {
            EditablePost postToDelete = GetEditablePost(id);
            if(postToDelete != null)
                DeleteChildPosts(postToDelete);
        }
        public static void MovePost(int postID, int? newParentPostID) {
            int newParentID = Convert.ToInt32(newParentPostID);
            if(GetEditablePost(postID).ParentID == newParentID || IsParentPost(postID, newParentID))
                return;
            GetEditablePost(postID).ParentID = newParentID;
        }

        static void DeleteChildPosts(EditablePost post) {
            List<EditablePost> childPosts = GetEditableChildPosts(post.PostID);
            if(childPosts != null) {
                foreach(EditablePost childPost in childPosts) {
                    DeleteChildPosts(childPost);
                }
            }
            GetEditablePosts().Remove(post);
        }
        static bool IsParentPost(int parentID, int childID) {
            EditablePost post;
            int postID = childID;
            while(postID != 0) {
                post = GetEditablePost(postID);
                if(post.PostID == parentID)
                    return true;
                postID = (int)post.ParentID;
            }
            return false;
        }
    }

    public class EditablePost {
        public int PostID { get; set; }

        public int? ParentID { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "From is required")]
        [StringLength(50, ErrorMessage = "Must be under 50 characters")]
        public string From { get; set; }

        public string Text { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime PostDate { get; set; }

        bool? isNew;
        public bool? IsNew {
            get { return isNew; }
            set { isNew = value == null ? false : value; }
        }

        bool? hasAttachment;
        public bool? HasAttachment {
            get { return hasAttachment; }
            set { hasAttachment = value == null ? false : value; }
        }
    }
}
