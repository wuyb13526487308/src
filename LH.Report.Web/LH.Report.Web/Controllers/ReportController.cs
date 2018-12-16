using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.XtraReports.UI;
using DevExpress.Web.ASPxClasses.Internal;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public override string Name {
            get { return "Report"; }
        }

        public ActionResult ReportViewerPartial(string reportID) {
            return PartialView("SampleViewerPartial", ReportDemoHelper.CreateModel(reportID));
        }

        public ActionResult ReportViewerExportTo(string reportID) {
            return ReportViewerExtension.ExportTo(ReportDemoHelper.CreateModel(reportID).Report);
        }

        protected override int IECompatibilityVersion { get { return 8; } }
        protected override bool IsDemoRequiredCompatibilityMode() {
            return RenderUtils.Browser.IsIE && RenderUtils.Browser.Version > 8;
        }
    }

    public static class ReportDemoHelper {
        public const string ParametersSessionKey = "ReportDemoParameters";
        class ReportRegistrationItem {
            public Func<XtraReport> ReportBuilder { get; set; }
            public string ParametersView { get; set; }
        }
        static readonly Dictionary<string, ReportRegistrationItem> reports = new Dictionary<string, ReportRegistrationItem> {
            { "Table", new ReportRegistrationItem() {
                ReportBuilder = () => new XtraReportsDemos.TableReport.Report(new ReportsDataProvider()) { DataAdapter = null },
                ParametersView = "TableReportParametersPartial"
                }
            },
            { "MasterDetail", new ReportRegistrationItem() { ReportBuilder = () => new XtraReportsDemos.MasterDetailReport.Report().Fill() } },
            { "ReportMerging", new ReportRegistrationItem() { ReportBuilder = () => new XtraReportsDemos.ReportMerging.MergedReport().Fill() } },
            { "SideBySide", new ReportRegistrationItem() { 
                ReportBuilder = () => new XtraReportsDemos.SideBySideReports.EmployeeComparisonReport().Fill(),
                ParametersView = "SideBySideReportParametersPartial" 
                }
            },
            { "IListDataSource", new ReportRegistrationItem() { ReportBuilder = () => new XtraReportsDemos.IListDatasource.Report() } },
            { "VerticalAnchoring", new ReportRegistrationItem() { ReportBuilder = () => new XtraReportsDemos.AnchorVertical.Report().Fill() } },
            { "Chart", new ReportRegistrationItem() { ReportBuilder = () => new XtraReportsDemos.Charts.Report().Fill() } },
            { "XRPivotGrid", new ReportRegistrationItem() { ReportBuilder = () => new XtraReportsDemos.PivotGrid.Report().Fill() } },
            { "PivotGridAndChart", new ReportRegistrationItem() { ReportBuilder = () => new XtraReportsDemos.PivotGridAndChart.Report().Fill() } },
            { "FormattingRules", 
                new ReportRegistrationItem() { ReportBuilder = () => new XtraReportsDemos.FormattingRules.Report() { FilterString = "[OrderDate] Between(#1996-01-01#, #1997-01-01#)" } .Fill(),
                ParametersView = "FormattingRulesReportParametersPartial" 
                }
            },
            { "FallCatalog", new ReportRegistrationItem() { 
                ReportBuilder = () => new XtraReportsDemos.NorthwindTraders.CatalogReport().Fill(), 
                ParametersView = "FallCatalogReportParametersPartial" }  
            },
            { "Thumbnails", new ReportRegistrationItem() { ReportBuilder = () => {
                var report = new XtraReportsDemos.ShrinkGrow.Report() {
                    PaperKind = System.Drawing.Printing.PaperKind.A5,
                    Landscape = true
                };
                report.Margins.Left = 90;
                report.Margins.Right = 85;
                report.xrPictureBox1.BeforePrint += (s, e)=> ((XRPictureBox)s).Bookmark = string.Format("{0} {1}", report.GetCurrentColumnValue("FirstName"), report.GetCurrentColumnValue("LastName"));
                report.Fill();
                return report;
            } } }
        };
        public static ReportsDemoModel CreateModel(string reportID) {
            ReportsDemoModel model = 
             new ReportsDemoModel()
            {
                ReportID = reportID,
                Report = GetReport(reportID),
                ParametersView = GetParametersViewName(reportID)
            };

            return model;
        }

        public static ReportsDemoModel CreateModel(string reportID, Dictionary<string, string> parameter) {
            var model = CreateModel(reportID);
            if(parameter != null) {
                foreach(var key in parameter.Keys) {
                    DevExpress.XtraReports.Parameters.Parameter param = model.Report.Parameters[key];
                    if(param == null)
                        continue;
                    param.Value = ConvertType(parameter[key], param.Type);
                }
            }
            return model;
        }
        static XtraReport GetReport(string reportID) {
            return reports[reportID].ReportBuilder();
        }
        static string GetParametersViewName(string reportID) {
            return reports[reportID].ParametersView;
        }
        static object ConvertType(string stringValue, Type type) {
            var converter = System.ComponentModel.TypeDescriptor.GetConverter(type);
            return converter.IsValid(stringValue) ? converter.ConvertFrom(stringValue) : null;
        }
    }
}
