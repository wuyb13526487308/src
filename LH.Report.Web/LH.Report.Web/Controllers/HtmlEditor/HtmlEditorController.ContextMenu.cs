using System;
using System.Web.Mvc;
using DevExpress.Utils;
using DevExpress.Web.ASPxEditors;
using DevExpress.Web.ASPxHtmlEditor;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class HtmlEditorController : DemoController {
        HtmlEditorContextMenuItemCollection ContextMenuItems {
            get {
                if(Session["ContextMenuItems"] == null) {
                    HtmlEditorContextMenuItemCollection items = new HtmlEditorContextMenuItemCollection(null);
                    items.CreateDefaultItems();
                    items.Insert(0, new HtmlEditorContextMenuItem("Add Title...", "AddTitle"));
                    items.Insert(1, new HtmlEditorContextMenuItem("Change Title...", "ChangeTitle"));
                    items.Insert(2, new HtmlEditorContextMenuItem("Remove Title", "RemoveTitle"));
                    ContextMenuItems = items;
                }
                return (HtmlEditorContextMenuItemCollection)Session["ContextMenuItems"];
            }
            set {
                Session["ContextMenuItems"] = value;
            }
        }

        [HttpGet]
        public ActionResult ContextMenu() {
            ContextMenuItems = null;
            return ContextMenuCore(ContextMenuItems);
        }
        [HttpPost]
        public ActionResult ContextMenu(FormCollection form) {
            string[] selectedItems = ListBoxExtension.GetSelectedValues<string>("lbContextMenuItems");
            if(selectedItems != null) {
                ContextMenuItems.ForEach(i => i.Visible = false);
                Array.ForEach(selectedItems, i => ContextMenuItems[i].Visible = true);
            }
            return ContextMenuCore(ContextMenuItems);
        }
        ActionResult ContextMenuCore(HtmlEditorContextMenuItemCollection contextMenuItems) {
            ViewData["AllowContextMenu"] = (DefaultBoolean)Enum.Parse(typeof(DefaultBoolean), ComboBoxExtension.GetValue<string>("cbContextMenu") ?? "True");
            ViewData["ContextMenuItems"] = contextMenuItems;
            ViewData["lbContextMenuItems"] = contextMenuItems.ConvertAll<ListEditItem>(i =>
            {
                string text = i.Text;
                if(text.Contains("Title"))
                    text = string.Format("<b>{0}</b>", text);
                ListEditItem item = new ListEditItem(text, i.CommandName);
                item.Selected = i.Visible;
                return item;
            });
            return DemoView("ContextMenu");
        }

        public ActionResult ContextMenuPartial() {
            return PartialView("ContextMenuPartial");
        }
        public ActionResult ContextMenuImageUpload() {
            HtmlEditorExtension.SaveUploadedImage("heContextMenu", HtmlEditorDemosHelper.ImageUploadValidationSettings, HtmlEditorDemosHelper.UploadDirectory);
            return null;
        }
    }
}
