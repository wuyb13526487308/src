using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DevExpress.Utils;
using DevExpress.Web.ASPxHtmlEditor;
using DevExpress.Web.ASPxUploadControl;
using DevExpress.Web.Mvc;
using DevExpress.Web.ASPxFileManager;

namespace DevExpress.Web.Demos {
    public partial class HtmlEditorController : DemoController {
        public override string Name { get { return "HtmlEditor"; } }

        public ActionResult Index() {
            return RedirectToAction("Features");
        }
    }

    public class HtmlEditorModel {
        public HtmlEditorModel(string html) : this(html, null) { }
        public HtmlEditorModel(string html, IEnumerable<string> cssFiles) {
            Html = html;
            CssFiles = cssFiles;
        }

        public string Html { get; set; }
        public IEnumerable<string> CssFiles { get; set; }
    }

    public class HtmlEditorDemosHelper {
        public const string ImagesDirectory = "~/Content/HtmlEditor/Images/";
        public const string ThumbnailsDirectory = "~/Content/HtmlEditor/Thumbnails/";
        public const string UploadDirectory = ImagesDirectory + "Upload/";
        public const string ImportContentDirectory = "~/Content/HtmlEditor/Imported";

        public static readonly ValidationSettings ImageUploadValidationSettings = new ValidationSettings {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".png" },
            MaxFileSize = 4000000
        };

        static HtmlEditorValidationSettings validationSettings;
        public static HtmlEditorValidationSettings ValidationSettings {
            get {
                if(validationSettings == null) {
                    validationSettings = new HtmlEditorValidationSettings();
                    validationSettings.RequiredField.IsRequired = true;
                }
                return validationSettings;
            }
        }
        
        static MVCxHtmlEditorImageSelectorSettings imageSelectorSettings;
        public static HtmlEditorImageSelectorSettings ImageSelectorSettings {
            get {
                if(imageSelectorSettings == null) {
                    imageSelectorSettings = new MVCxHtmlEditorImageSelectorSettings(null);
                    HtmlEditorDemosHelper.SetHtmlEditorImageSelectorSettings(imageSelectorSettings);
                }
                return imageSelectorSettings;
            }
        }
        
        public static void OnValidation(object sender, HtmlEditorValidationEventArgs e) {
            const int MaxLength = 50;
            string CustomErrorText = string.Format("Custom validation fails because the HTML content&prime;s length exceeds {0} characters.", MaxLength);

            if(e.Html.Length > MaxLength) {
                e.IsValid = false;
                e.ErrorText = CustomErrorText;
            }
        }

        public static MVCxHtmlEditorImageSelectorSettings SetHtmlEditorImageSelectorSettings(MVCxHtmlEditorImageSelectorSettings settingsImageSelector) {
            settingsImageSelector.UploadCallbackRouteValues = new { Controller = "HtmlEditor", Action = "FeaturesImageSelectorUpload" };

            settingsImageSelector.Enabled = true;
            settingsImageSelector.CommonSettings.RootFolder = HtmlEditorDemosHelper.ImagesDirectory;
            settingsImageSelector.CommonSettings.ThumbnailFolder = HtmlEditorDemosHelper.ThumbnailsDirectory;
            settingsImageSelector.CommonSettings.AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".jpe", ".gif", ".png" };
            settingsImageSelector.EditingSettings.AllowCreate = true;
            settingsImageSelector.EditingSettings.AllowDelete = true;
            settingsImageSelector.EditingSettings.AllowMove = true;
            settingsImageSelector.EditingSettings.AllowRename = true;
            settingsImageSelector.UploadSettings.Enabled = true;
            settingsImageSelector.FoldersSettings.ShowLockedFolderIcons = true;

            settingsImageSelector.PermissionSettings.AccessRules.Add(
                new FileManagerFolderAccessRule
                {
                    Path = "",
                    Upload = Rights.Deny
                },
                new FileManagerFolderAccessRule
                {
                    Path = "Upload",
                    Upload = Rights.Allow
                });
            return settingsImageSelector;
        }

        public static HtmlEditorSettings SetHtmlEditorExportSettings(HtmlEditorSettings settings) {
            settings.Name = "heImportExport";
            settings.CallbackRouteValues = new { Controller = "HtmlEditor", Action = "ImportExportPartial" };
            settings.ExportRouteValues = new { Controller = "HtmlEditor", Action = "ExportTo" };
            settings.Width = Unit.Percentage(100);
            
            var toolbar = settings.Toolbars.Add();
            toolbar.Items.Add(new ToolbarUndoButton());
            toolbar.Items.Add(new ToolbarRedoButton());
            toolbar.Items.Add(new ToolbarBoldButton(true));
            toolbar.Items.Add(new ToolbarItalicButton());
            toolbar.Items.Add(new ToolbarUnderlineButton());
            toolbar.Items.Add(new ToolbarStrikethroughButton());
            toolbar.Items.Add(new ToolbarInsertImageDialogButton(true));
            ToolbarExportDropDownButton saveButton = new ToolbarExportDropDownButton(true);
            saveButton.CreateDefaultItems();
            toolbar.Items.Add(saveButton);

            settings.CssFiles.Add("~/Content/HtmlEditor/DemoCss/Export.css");

            return settings;
        }
    }

    public class HtmlEditorFeaturesDemoOptions {
        public HtmlEditorFeaturesDemoOptions() {
            UpdateDeprecatedElements = true;
            UpdateBoldItalic = true;
            EnterMode = HtmlEditorEnterMode.Default;
            AllowContextMenu = DefaultBoolean.True;
            AllowDesignView = true;
            AllowHtmlView = true;
            AllowPreview = true;
        }

        public bool AllowScripts { get; set; }
        public bool AllowIFrames { get; set; }
        public bool AllowFormElements { get; set; }
        public bool UpdateDeprecatedElements { get; set; }
        public bool UpdateBoldItalic { get; set; }
        public HtmlEditorEnterMode EnterMode { get; set; }
        public DefaultBoolean AllowContextMenu { get; set; }
        public bool AllowDesignView { get; set; }
        public bool AllowHtmlView { get; set; }
        public bool AllowPreview { get; set; }
    }
}
