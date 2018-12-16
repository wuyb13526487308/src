using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxTreeList;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TreeListController : DemoController {
        public override string Name { get { return "TreeList"; } }

        public ActionResult Index() {
            return DataBinding();
        }
    }

    public delegate ActionResult TreeListExportMethod(DevExpress.Web.Mvc.TreeListSettings settings, object dataObject);
    public class TreeListExportType {
        public string Title { get; set; }
        public TreeListExportMethod Method { get; set; }
    }

    public class TreeListExportDemoOptions {
        bool autoWidth;
        bool expandAll;
        bool showTreeButtons;

        public TreeListExportDemoOptions() {
        }

        public bool EnableAutoWidth {
            get { return autoWidth; }
            set { autoWidth = value; }
        }
        public bool ExpandAllNodes {
            get { return expandAll; }
            set { expandAll = value; }
        }
        public bool ShowTreeButtons {
            get { return showTreeButtons; }
            set { showTreeButtons = value; }
        }
    }

    public class TreeListMultipleSelectionDemoOptions {
        bool recursiveSelection;
        bool allowSelectAll;
        string selectMode;

        public TreeListMultipleSelectionDemoOptions() {
        }
        
        public bool EnableRecursiveSelection {
            get { return recursiveSelection; }
            set { recursiveSelection = value; }
        }
        public bool AllowSelectAll {
            get { return allowSelectAll; }
            set { allowSelectAll = value; }
        }
        public string SelectMode {
            get { return selectMode; }
            set { selectMode = value; }
        }
    }

    public class TreeListDemoHelper {
        public static Color GetBudgetColor(int value) {
            decimal coeff = value / 1000 - 22;
            int a = (int)(0.02165M * coeff);
            int b = (int)(0.09066M * coeff);
            return Color.FromArgb(255, 235 - a, 177 - b);
        }
        public static List<SelectListItem> GetSelectModes() {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = "All nodes", Value = "All", Selected = true },
                new SelectListItem() { Text = "Child nodes", Value = "Child" },
                new SelectListItem() { Text = "Parent nodes", Value = "Parent" },
                new SelectListItem() { Text = "Level > 2", Value = "DepthOverTwo" }
            };
        }

        public static EditablePost GetEditedPost(TreeListEditFormTemplateContainer container) {
            return new EditablePost {
                From = (string)DataBinder.Eval(container.DataItem, "From"),
                Subject = (string)DataBinder.Eval(container.DataItem, "Subject"),
                PostDate = (DateTime)(DataBinder.Eval(container.DataItem, "PostDate") ?? new DateTime()),
                Text = (string)DataBinder.Eval(container.DataItem, "Text"),
                HasAttachment = (bool?)DataBinder.Eval(container.DataItem, "HasAttachment"),
                IsNew = (bool?)DataBinder.Eval(container.DataItem, "IsNew")
            };
        }

        static Dictionary<string, TreeListExportType> exportTypes;
        public static Dictionary<string, TreeListExportType> ExportTypes {
            get {
                if(exportTypes == null)
                    exportTypes = CreateExportTypes();
                return exportTypes;
            }
        }
        static Dictionary<string, TreeListExportType> CreateExportTypes() {
            Dictionary<string, TreeListExportType> types = new Dictionary<string, TreeListExportType>();
            types.Add("PDF", new TreeListExportType { Title = "Export to PDF", Method = TreeListExtension.ExportToPdf });
            types.Add("XLS", new TreeListExportType { Title = "Export to XLS", Method = TreeListExtension.ExportToXls });
            types.Add("XLSX", new TreeListExportType { Title = "Export to XLSX", Method = TreeListExtension.ExportToXlsx });
            types.Add("RTF", new TreeListExportType { Title = "Export to RTF", Method = TreeListExtension.ExportToRtf });
            return types;
        }

        static DevExpress.Web.Mvc.TreeListSettings exportTreeListSettings;
        public static DevExpress.Web.Mvc.TreeListSettings CreateExportTreeListSettings(TreeListExportDemoOptions options) {
            if(exportTreeListSettings == null)
                exportTreeListSettings = CreateTreeListSettings();
            exportTreeListSettings.SettingsExport.PrintSettings.AutoWidth = options.EnableAutoWidth;
            exportTreeListSettings.SettingsExport.PrintSettings.ExpandAllNodes = options.ExpandAllNodes;
            exportTreeListSettings.SettingsExport.PrintSettings.ShowTreeButtons = options.ShowTreeButtons;
            return exportTreeListSettings;
        }
        static DevExpress.Web.Mvc.TreeListSettings CreateTreeListSettings() {
            DevExpress.Web.Mvc.TreeListSettings settings = new DevExpress.Web.Mvc.TreeListSettings();

            settings.Name = "treeList";
            settings.CallbackRouteValues = new { Controller = "TreeList", Action = "ExportPartial" };
            settings.Width = Unit.Percentage(100);
            settings.AutoGenerateColumns = false;

            settings.KeyFieldName = "ID";
            settings.ParentFieldName = "ParentID";
            settings.RootValue = 0;

            settings.Columns.Add("Name", "Department");
            settings.Columns.Add(
                column => {
                    column.FieldName = "Budget";
                    column.PropertiesEdit.DisplayFormatString = "{0:C}";
                }
            );
            settings.Columns.Add("Location");
            settings.Columns.Add("Phone1", "Phone");

            settings.Summary.Add(DevExpress.Data.SummaryItemType.Count, "Name");
            settings.Summary.Add(
                item => {
                    item.SummaryType = DevExpress.Data.SummaryItemType.Sum;
                    item.FieldName = "Budget";
                    item.ShowInColumn = "Budget";
                    item.DisplayFormat = "{0:C}";
                }
            );

            settings.Settings.ShowFooter = true;
            settings.Settings.ShowGroupFooter = true;
            settings.Settings.GridLines = GridLines.Both;
            settings.SettingsBehavior.ExpandCollapseAction = TreeListExpandCollapseAction.NodeDblClick;
            settings.SettingsExport.Styles.Header.HorizontalAlign = HorizontalAlign.Left;

            settings.PreRender = (sender, e) => {
                ((MVCxTreeList)sender).ExpandToLevel(2);
            };

            return settings;
        }
    }
}
