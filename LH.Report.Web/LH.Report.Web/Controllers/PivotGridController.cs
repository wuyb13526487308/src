using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using System.Web.UI.WebControls;
using DevExpress.XtraPivotGrid;
using DevExpress.Utils;
using System.Collections.Generic;
using DevExpress.XtraPivotGrid.Customization;
using DevExpress.XtraPivotGrid.Data;

namespace DevExpress.Web.Demos {
    public partial class PivotGridController: DemoController {
        public override string Name { get { return "PivotGrid"; } }

        public ActionResult Index() {
            return RedirectToAction("SortBySummary");
        }
    }

    public class PivotGridChartIntegrationDemoOptions {
        public PivotGridChartIntegrationDemoOptions() {
            ChartType = XtraCharts.ViewType.Line;
            ShowRowGrandTotals = true;
        }
        public XtraCharts.ViewType ChartType { get; set; }
        public bool ShowColumnGrandTotals { get; set; }
        public bool GenerateSeriesFromColumns { get; set; }
        public bool ShowPointLabels { get; set; }
        public bool ShowRowGrandTotals { get; set; }
    }

    public enum PivotGridExportFormats { Pdf, Excel, Mht, Rtf, Text, Html }
    public class PivotGridExportDemoOptions {
        public PivotGridExportDemoOptions() {
            PrintFilterHeaders = true;
            PrintColumnHeaders = true;
            PrintRowHeaders = true;
            PrintDataHeaders = true;
        }

        public bool PrintHeadersOnEveryPage { get; set; }
        public bool PrintFilterHeaders { get; set; }
        public bool PrintColumnHeaders { get; set; }
        public bool PrintRowHeaders { get; set; }
        public bool PrintDataHeaders { get; set; }
        public PivotGridExportFormats ExportType { get; set; }
    }

    public enum CustomerReportKind { Customers, Filtered, Top2Products, Top10Customers };
    public class PivotGridReportsDemoOptions {
        public CustomerReportKind DemoKind { get; set; }
        public int FilterYearIndex { get; set; }
        public int FilterQuarterIndex { get; set; }

        public static PivotGridReportsDemoOptions Default {
            get {
                return new PivotGridReportsDemoOptions() {
                    DemoKind = CustomerReportKind.Filtered,
                    FilterYearIndex = -1,
                    FilterQuarterIndex = -1
                };
            }
        }
    }

    public class PivotGridFieldsCustomizationDemoOptions {
        public PivotGridFieldsCustomizationDemoOptions() {
            AllowDragFields = true;
            AllowDragFieldsInCustomizationForm = true;
        }

        public bool AllowDragFields { get; set; }
        public bool AllowDragFieldsInCustomizationForm { get; set; }
        public CustomizationFormLayout CustomizationFormLayout { get; set; }
        public CustomizationFormStyle CustomizationFormStyle { get; set; }
    }

    public class PivotGridDemoHelper {
        const string ProviderDownloadUrl = "http://www.microsoft.com/downloads/details.aspx?FamilyID=50b97994-8453-4998-8226-fa42ec403d17#ASOLEDB";
        public static string OLAPConnectionString {
            get {
                if (!OLAPMetaGetter.IsProviderAvailable) 
                    return null;
                return string.Format(@"Provider=msolap;Initial Catalog=Northwind;Cube Name=Northwind;Data Source=|DataDirectory|\Northwind{0}.cub;",
                    IntPtr.Size == 4 ? string.Empty : "64");
            }
        }
        public static string NoProviderErrorString {
            get {
                return "To connect to olap cubes, you should have Microsoft SQL Server 2005<br />" +
                       "Analysis Services 9.0 (or newer) OLE DB Provider installed on your system. You can get<br />" +
                       "the latest version of this provider here:<br />" +
                       "<a href=\"" + ProviderDownloadUrl + "\" target=\"_blank\">" + ProviderDownloadUrl + "</a>.";
            }
        }

        static PivotGridSettings compactLayoutPivotGridSettings;
        public static PivotGridSettings CompactLayoutPivotGridSettings {
            get {
                if (compactLayoutPivotGridSettings == null)
                    compactLayoutPivotGridSettings = CreateCompactLayoutPivotGridSettings();
                return compactLayoutPivotGridSettings;
            }
        }
        static PivotGridSettings CreateCompactLayoutPivotGridSettings() {
            PivotGridSettings settings = new PivotGridSettings();
            settings.Name = "pivotGrid";
            settings.CallbackRouteValues = new { Controller = "PivotGrid", Action = "CompactLayoutPartial" };
            settings.OptionsPager.NumericButtonCount = 7;
            settings.OptionsPager.RowsPerPage = 15;
            settings.OptionsView.ShowHorizontalScrollBar = true;
            settings.OptionsView.RowTotalsLocation = PivotRowTotalsLocation.Tree;
            settings.OptionsView.ShowTotalsForSingleValues = true;
            settings.OptionsView.ShowColumnHeaders = false;
            settings.OptionsView.ShowDataHeaders = false;
            settings.OptionsView.ShowFilterHeaders = false;
            settings.OptionsView.ShowRowHeaders = false;
            settings.Width = Unit.Pixel(400);


            settings.PivotCustomizationExtensionSettings.Name = "pivotCustomization";
            settings.PivotCustomizationExtensionSettings.AllowedLayouts = CustomizationFormAllowedLayouts.BottomPanelOnly1by4 | CustomizationFormAllowedLayouts.BottomPanelOnly2by2 |
                CustomizationFormAllowedLayouts.StackedDefault | CustomizationFormAllowedLayouts.StackedSideBySide;
            settings.PivotCustomizationExtensionSettings.Layout = CustomizationFormLayout.BottomPanelOnly2by2;
            settings.PivotCustomizationExtensionSettings.AllowSort = true;
            settings.PivotCustomizationExtensionSettings.AllowFilter = true;
            settings.PivotCustomizationExtensionSettings.Height = Unit.Pixel(480);
            settings.PivotCustomizationExtensionSettings.Width = Unit.Pixel(400);

            settings.Fields.Add(field => {
                field.FieldName = "Country";
                field.Area = PivotArea.RowArea;
                field.AreaIndex = 0;
            });
            settings.Fields.Add(field => {
                field.Caption = "Category Name";
                field.FieldName = "CategoryName";
                field.Area = PivotArea.RowArea;
                field.AreaIndex = 1;
            });
            settings.Fields.Add(field => {
                field.Caption = "Product Name";
                field.FieldName = "ProductName";
                field.Area = PivotArea.RowArea;
                field.AreaIndex = 2;
            });
            settings.Fields.Add(field => {
                field.Caption = "Customer";
                field.FieldName = "Sales_Person";
                field.Area = PivotArea.RowArea;
                field.AreaIndex = 3;
            });
            settings.Fields.Add(field => {
                field.Caption = "Order Year";
                field.FieldName = "OrderDate";
                field.Area = PivotArea.RowArea;
                field.AreaIndex = 4;
                field.GroupInterval = PivotGroupInterval.DateYear;
            });
            settings.Fields.Add(field => {
                field.Caption = "Order Quarter";
                field.FieldName = "OrderDate";
                field.Area = PivotArea.RowArea;
                field.AreaIndex = 5;
                field.GroupInterval = PivotGroupInterval.DateQuarter;
                field.ValueFormat.FormatString = "Qtr {0}";
                field.ValueFormat.FormatType = FormatType.Numeric;
            });
            settings.Fields.Add("Quantity", PivotArea.DataArea);
            settings.Fields.Add("UnitPrice", PivotArea.FilterArea);

            settings.PreRender = (sender, e) => {
                MVCxPivotGrid pivotGrid = (MVCxPivotGrid)sender;
                pivotGrid.CollapseAll();
                pivotGrid.ExpandValue(false, new object[] { "UK" });
                pivotGrid.ExpandValue(false, new object[] { "UK", "Condiments" });
                pivotGrid.ExpandValue(false, new object[] { "UK", "Condiments", "Chef Anton's Cajun Seasoning" });
                pivotGrid.ExpandValue(false, new object[] { "UK", "Condiments", "Chef Anton's Cajun Seasoning", "Robert King" });
                pivotGrid.ExpandValue(false, new object[] { "UK", "Condiments", "Chef Anton's Cajun Seasoning", "Robert King", 1996 });
                pivotGrid.ExpandValue(false, new object[] { "UK", "Condiments", "Chef Anton's Cajun Seasoning", "Robert King", 1997 });
                pivotGrid.ExpandValue(false, new object[] { "UK", "Condiments", "Genen Shouyu" });
                pivotGrid.ExpandValue(false, new object[] { "UK", "Condiments", "Genen Shouyu", "Michael Suyama" });
            };
            return settings;
        }

        static PivotGridSettings drillDownPivotGridSettings;
        public static PivotGridSettings DrillDownPivotGridSettings {
            get {
                if (drillDownPivotGridSettings == null)
                    drillDownPivotGridSettings = CreateDrillDownPivotGridSettings();
                return drillDownPivotGridSettings;
            }
        }
        static PivotGridSettings CreateDrillDownPivotGridSettings() {
            PivotGridSettings settings = CreatePivotGridSettings("DrillDownPivotGridPartial");
            settings.Styles.CellStyle.Cursor = "pointer";
            settings.OptionsView.ShowFilterHeaders = false;
            settings.ClientSideEvents.CellClick = "OnPivotGridCellClick";

            settings.Fields["Year"].UnboundFieldName = "Year";
            settings.Fields["Product"].Area = PivotArea.RowArea;
            return settings;
        }

        static PivotGridSettings exportPivotGridSettings;
        public static PivotGridSettings ExportPivotGridSettings {
            get {
                if (exportPivotGridSettings == null)
                    exportPivotGridSettings = CreatePivotGridSettings("ExportPartial");
                return exportPivotGridSettings;
            }
        }
        public static PivotGridSettings GetPivotGridExportSettings(PivotGridExportDemoOptions options) {
            PivotGridSettings exportSettings = ExportPivotGridSettings;
            exportSettings.SettingsExport.OptionsPrint.PrintHeadersOnEveryPage = options.PrintHeadersOnEveryPage;
            exportSettings.SettingsExport.OptionsPrint.PrintFilterHeaders = ConvertToDefaultBoolean(options.PrintFilterHeaders);
            exportSettings.SettingsExport.OptionsPrint.PrintColumnHeaders = ConvertToDefaultBoolean(options.PrintColumnHeaders);
            exportSettings.SettingsExport.OptionsPrint.PrintRowHeaders = ConvertToDefaultBoolean(options.PrintRowHeaders);
            exportSettings.SettingsExport.OptionsPrint.PrintDataHeaders = ConvertToDefaultBoolean(options.PrintDataHeaders);
            return exportSettings;
        }
        static PivotGridSettings CreatePivotGridSettings(string actionName) {
            PivotGridSettings settings = new PivotGridSettings();
            settings.Name = "pivotGrid";
            settings.CallbackRouteValues = new { Controller = "PivotGrid", Action = actionName };
            settings.Width = Unit.Percentage(100);
            settings.OptionsView.ShowHorizontalScrollBar = true;

            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.AreaIndex = 0;
                field.Caption = "Product";
                field.FieldName = "ProductName";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.RowArea;
                field.AreaIndex = 0;
                field.Caption = "Customer";
                field.FieldName = "CompanyName";
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.ColumnArea;
                field.AreaIndex = 0;
                field.Caption = "Year";
                field.FieldName = "OrderDate";
                field.GroupInterval = PivotGroupInterval.DateYear;
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.DataArea;
                field.AreaIndex = 0;
                field.Caption = "Product Amount";
                field.FieldName = "ProductAmount";
                field.CellFormat.FormatString = "c";
                field.CellFormat.FormatType = FormatType.Custom;
            });
            settings.Fields.Add(field => {
                field.Area = PivotArea.FilterArea;
                field.AreaIndex = 1;
                field.Caption = "Quarter";
                field.FieldName = "OrderDate";
                field.GroupInterval = PivotGroupInterval.DateQuarter;
            });

            return settings;
        }
        static DefaultBoolean ConvertToDefaultBoolean(bool value) {
            return value ? DefaultBoolean.True : DefaultBoolean.False;
        }

        static Dictionary<PivotGridExportFormats, PivotGridExportType> exportTypes;
        public static Dictionary<PivotGridExportFormats, PivotGridExportType> ExportTypes {
            get {
                if (exportTypes == null)
                    exportTypes = CreateExportTypes();
                return exportTypes;
            }
        }
        public delegate ActionResult PivotGridExportMethod(PivotGridSettings settings, object dataObject);
        public class PivotGridExportType {
            public string Title { get; set; }
            public PivotGridExportMethod Method { get; set; }
        }
        static Dictionary<PivotGridExportFormats, PivotGridExportType> CreateExportTypes() {
            Dictionary<PivotGridExportFormats, PivotGridExportType> types = new Dictionary<PivotGridExportFormats, PivotGridExportType>();
            types.Add(PivotGridExportFormats.Pdf, new PivotGridExportType { Title = "Export to PDF", Method = PivotGridExtension.ExportToPdf });
            types.Add(PivotGridExportFormats.Excel, new PivotGridExportType { Title = "Export to XLS", Method = PivotGridExtension.ExportToXls });
            types.Add(PivotGridExportFormats.Mht, new PivotGridExportType { Title = "Export to MHT", Method = PivotGridExtension.ExportToMht });
            types.Add(PivotGridExportFormats.Rtf, new PivotGridExportType { Title = "Export to RTF", Method = PivotGridExtension.ExportToRtf });
            types.Add(PivotGridExportFormats.Text, new PivotGridExportType { Title = "Export to TEXT", Method = PivotGridExtension.ExportToText });
            types.Add(PivotGridExportFormats.Html, new PivotGridExportType { Title = "Export to HTML", Method = PivotGridExtension.ExportToHtml });
            return types;
        }

        public static void UpdatePivotGridLayoutForSampleReportsDemo(MVCxPivotGrid pivotGrid, PivotGridReportsDemoOptions options) {
            ChangePivotGridFieldLayout(pivotGrid, options ?? new PivotGridReportsDemoOptions());
        }
        static void ChangePivotGridFieldLayout(MVCxPivotGrid pivotGrid, PivotGridReportsDemoOptions options) {
            pivotGrid.BeginUpdate();
            pivotGrid.Fields["Year"].Area = PivotArea.ColumnArea;
            pivotGrid.Fields["Year"].AreaIndex = 0;
            pivotGrid.Fields["Quarter"].Area = PivotArea.ColumnArea;
            pivotGrid.Fields["Quarter"].AreaIndex = 1;
            pivotGrid.Fields["ProductAmount"].Area = PivotArea.DataArea;
            pivotGrid.Fields["Customer"].Area = PivotArea.RowArea;
            pivotGrid.Fields["Customer"].AreaIndex = 0;
            pivotGrid.Fields["Customer"].SortOrder = options.DemoKind == CustomerReportKind.Top10Customers ?
                PivotSortOrder.Descending : PivotSortOrder.Ascending;
            pivotGrid.Fields["Customer"].TopValueCount = 0;
            pivotGrid.Fields["Customer"].SortBySummaryInfo.FieldName = string.Empty;
            pivotGrid.Fields["ProductName"].Area = PivotArea.FilterArea;
            pivotGrid.Fields["ProductName"].SortOrder = options.DemoKind == CustomerReportKind.Top2Products ?
                PivotSortOrder.Descending : PivotSortOrder.Ascending;
            pivotGrid.Fields["ProductName"].TopValueCount = 0;
            pivotGrid.Fields["ProductName"].SortBySummaryInfo.FieldName = string.Empty;
            pivotGrid.Fields["Customer"].SortOrder = options.DemoKind == CustomerReportKind.Top10Customers ?
                PivotSortOrder.Descending : PivotSortOrder.Ascending;
            pivotGrid.Fields["ProductName"].SortOrder = options.DemoKind == CustomerReportKind.Top2Products ?
                PivotSortOrder.Descending : PivotSortOrder.Ascending;

            switch (options.DemoKind) {
                case CustomerReportKind.Customers:
                    break;
                case CustomerReportKind.Filtered:
                    pivotGrid.Fields["Customer"].Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                    pivotGrid.Fields["ProductName"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                    break;
                case CustomerReportKind.Top2Products:
                    pivotGrid.Fields["ProductName"].Area = DevExpress.XtraPivotGrid.PivotArea.RowArea;
                    pivotGrid.Fields["ProductName"].TopValueCount = 2;
                    pivotGrid.Fields["ProductName"].SortBySummaryInfo.FieldName = "ProductAmount";
                    pivotGrid.Fields["Year"].Area = pivotGrid.Fields["Quarter"].Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                    break;
                case CustomerReportKind.Top10Customers:
                    pivotGrid.Fields["Customer"].TopValueCount = 10;
                    pivotGrid.Fields["Customer"].SortBySummaryInfo.FieldName = "ProductAmount";
                    pivotGrid.Fields["Year"].Area = pivotGrid.Fields["Quarter"].Area = DevExpress.XtraPivotGrid.PivotArea.FilterArea;
                    break;
            }
            ApplyFilter(pivotGrid, options);
            pivotGrid.EndUpdate();
        }
        static void ApplyFilter(MVCxPivotGrid pivotGrid, PivotGridReportsDemoOptions options) {
            pivotGrid.BeginUpdate();
            ApplyFilter(pivotGrid.Fields["Year"], options.FilterYearIndex, 1995);
            ApplyFilter(pivotGrid.Fields["Quarter"], options.FilterQuarterIndex, 0);
            pivotGrid.EndUpdate();
        }
        static void ApplyFilter(ASPxPivotGrid.PivotGridField field, int selectedIndex, int filterIndex) {
            field.FilterValues.Clear();
            if (selectedIndex > 0) {
                field.FilterValues.FilterType = PivotFilterType.Included;
                field.FilterValues.Add(filterIndex + selectedIndex);
            }
            else {
                field.FilterValues.FilterType = DevExpress.XtraPivotGrid.PivotFilterType.Excluded;
            }
        }

        static PivotGridSettings pivotChartIntegrationSettings;
        public static PivotGridSettings PivotChartIntegrationSettings() {
            return PivotChartIntegrationSettings(null);
        }
        public static PivotGridSettings PivotChartIntegrationSettings(PivotGridChartIntegrationDemoOptions options) {
            if (pivotChartIntegrationSettings == null)
                pivotChartIntegrationSettings = CreatePivotChartIntegrationSettings();
            if (options != null) {
                pivotChartIntegrationSettings.OptionsChartDataSource.ProvideColumnGrandTotals = options.ShowColumnGrandTotals;
                pivotChartIntegrationSettings.OptionsChartDataSource.ProvideRowGrandTotals = options.ShowRowGrandTotals;
                pivotChartIntegrationSettings.OptionsChartDataSource.ProvideDataByColumns = options.GenerateSeriesFromColumns;
            }
            return pivotChartIntegrationSettings;
        }
        static PivotGridSettings CreatePivotChartIntegrationSettings() {
            PivotGridSettings pivotGridSettings = new PivotGridSettings();
            pivotGridSettings.Name = "pivotGrid";
            pivotGridSettings.CallbackRouteValues = new { Controller = "PivotGrid", Action = "ChartsIntegrationPivotPartial" };
            pivotGridSettings.OptionsChartDataSource.DataProvideMode = PivotChartDataProvideMode.UseCustomSettings;
            pivotGridSettings.OptionsView.ShowFilterHeaders = false;
            pivotGridSettings.OptionsView.ShowHorizontalScrollBar = true;
            pivotGridSettings.Width = Unit.Percentage(100);

            pivotGridSettings.Fields.Add(field => {
                field.FieldName = "Extended_Price";
                field.Caption = "Extended Price";
                field.Area = PivotArea.DataArea;
                field.AreaIndex = 0;
            });
            pivotGridSettings.Fields.Add(field => {
                field.FieldName = "CategoryName";
                field.Caption = "Category Name";
                field.Area = PivotArea.RowArea;
                field.AreaIndex = 0;
            });
            pivotGridSettings.Fields.Add(field => {
                field.FieldName = "OrderDate";
                field.Caption = "Order Month";
                field.Area = PivotArea.ColumnArea;
                field.AreaIndex = 0;
                field.UnboundFieldName = "fieldOrderDate";
                field.GroupInterval = PivotGroupInterval.DateMonth;
            });
            pivotGridSettings.PreRender = (sender, e) => {
                int selectNumber = 4;
                var field = ((MVCxPivotGrid)sender).Fields["Category Name"];
                object[] values = field.GetUniqueValues();
                List<object> includedValues = new List<object>(values.Length / selectNumber);
                for (int i = 0; i < values.Length; i++) {
                    if (i % selectNumber == 0)
                        includedValues.Add(values[i]);
                }
                field.FilterValues.ValuesIncluded = includedValues.ToArray();
            };
            pivotGridSettings.ClientSideEvents.BeginCallback = "OnBeforePivotGridCallback";
            pivotGridSettings.ClientSideEvents.EndCallback = "UpdateChart";

            return pivotGridSettings;
        }
    }
}
