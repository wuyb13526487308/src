using DevExpress.Web.ASPxGridView;
using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public partial class GridViewController : DemoController {
        public override string Name { get { return "GridView"; } }

        static GridViewController() {
            EmailDataGenerator.Register();
        }

        public ActionResult Index() {
            return DataBinding();
        }
        public ActionResult EmployeeImage() {
            if(Request.QueryString[GridViewDemosHelper.ImageQueryKey] != null) {
                int employeeId = int.Parse(Request.QueryString[GridViewDemosHelper.ImageQueryKey]);
                Response.ContentType = "image";
                Binary photo = NorthwindDataProvider.GetEmployeePhoto(employeeId);
                if(photo != null)
                    Response.BinaryWrite(photo.ToArray());
                Response.End();
            }
            return null;
        }
    }

    public delegate string TweetsDemoReplaceDelegate(string text, Match match);
    public class TweetsDemoReplaceItem {
        public Regex RegEx { get; set; }
        public TweetsDemoReplaceDelegate ReplaceDelegate { get; set; }
    }

    public delegate ActionResult ExportMethod(GridViewSettings settings, object dataObject);
    public class ExportType {
        public string Title { get; set; }
        public ExportMethod Method { get; set; }
    }
    public class GridViewDemosHelper {
        public const string ImageQueryKey = "DXImage";
        public const string PageSizeSessionKey = "ed5e843d-cff7-47a7-815e-832923f7fb09";

        public static int PageSize {
            get {
                if(HttpContext.Current.Session[PageSizeSessionKey] == null)
                    return 2;
                return (int)HttpContext.Current.Session[PageSizeSessionKey];
            }
            set { HttpContext.Current.Session[PageSizeSessionKey] = value; }
        }

        public static string GetEmployeeImageRouteUrl() {
            return DevExpressHelper.GetUrl(new { Controller = "GridView", Action = "EmployeeImage" });
        }

        static Dictionary<string, ExportType> exportTypes;
        public static Dictionary<string, ExportType> ExportTypes {
            get {
                if(exportTypes == null)
                    exportTypes = CreateExportTypes();
                return exportTypes;
            }
        }
        static Dictionary<string, ExportType> CreateExportTypes() {
            Dictionary<string, ExportType> types = new Dictionary<string, ExportType>();
            types.Add("PDF", new ExportType { Title = "Export to PDF", Method = GridViewExtension.ExportToPdf });
            types.Add("XLS", new ExportType { Title = "Export to XLS", Method = GridViewExtension.ExportToXls });
            types.Add("XLSX", new ExportType { Title = "Export to XLSX", Method = GridViewExtension.ExportToXlsx });
            types.Add("RTF", new ExportType { Title = "Export to RTF", Method = GridViewExtension.ExportToRtf });
            types.Add("CSV", new ExportType { Title = "Export to CSV", Method = GridViewExtension.ExportToCsv });
            return types;
        }

        static GridViewSettings exportGridViewSettings;
        public static GridViewSettings ExportGridViewSettings {
            get {
                if(exportGridViewSettings == null)
                    exportGridViewSettings = CreateExportGridViewSettings();
                return exportGridViewSettings;
            }
        }
        static GridViewSettings CreateExportGridViewSettings() {
            GridViewSettings settings = new GridViewSettings();

            settings.Name = "gvExport";
            settings.CallbackRouteValues = new { Controller = "GridView", Action = "ExportPartial" };
            settings.Width = Unit.Percentage(100);

            settings.Columns.Add("CompanyName");
            settings.Columns.Add("City").GroupIndex = 1;
            settings.Columns.Add("Country").GroupIndex = 0;
            settings.Columns.Add("UnitPrice").PropertiesEdit.DisplayFormatString = "c";
            settings.Columns.Add("Quantity");
            var column = settings.Columns.Add("Total");
            column.UnboundType = DevExpress.Data.UnboundColumnType.Decimal;
            column.PropertiesEdit.DisplayFormatString = "c";
            settings.CustomUnboundColumnData = (sender, e) => {
                if(e.Column.FieldName == "Total") {
                    decimal price = (decimal)e.GetListSourceFieldValue("UnitPrice");
                    int quantity = Convert.ToInt32(e.GetListSourceFieldValue("Quantity"));
                    e.Value = price * quantity;
                }
            };

            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Count, "CompanyName");
            settings.TotalSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total");
            settings.Settings.ShowFooter = true;
            settings.SettingsExport.RenderBrick = (sender, e) => {
                if(e.RowType == GridViewRowType.Data && e.VisibleIndex % 2 == 0)
                    e.BrickStyle.BackColor = System.Drawing.Color.FromArgb(0xEE, 0xEE, 0xEE);
            };

            settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Sum, "Total");
            settings.GroupSummary.Add(DevExpress.Data.SummaryItemType.Count, "CompanyName");
            settings.Settings.ShowGroupPanel = true;
            return settings;
        }
    }
    public enum GridViewExportType { None, Pdf, Xls, Xlsx, Rtf, Csv }

}
