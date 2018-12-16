using System;
using System.Web.Mvc;
using DevExpress.Web.Mvc;
using DevExpress.XtraScheduler.Reporting;
using DevExpress.XtraScheduler;

namespace DevExpress.Web.Demos {
    public partial class SchedulerController: DemoController {
        public ActionResult ReportTemplates() {
            return DemoView("ReportTemplates", SchedulerDataHelper.DataObject);
        }
        public ActionResult ReportTemplatesPartial() {
            return PartialView("ReportTemplatesPartial", SchedulerDataHelper.DataObject);
        }
        public ActionResult ReportTemplatesViewerPartial() {
            XtraSchedulerReport report = !string.IsNullOrEmpty(ReportTemplateFileName) ? CreateSchedulerReport() : null;
            return PartialView("ReportTemplatesViewerPartial", report);
        }

        string ReportTemplateFileName { get { return Request["ReportTemplateFileName"]; } }
        DateTime StartDate { get { return !string.IsNullOrEmpty(Request["StartDate"]) ? Convert.ToDateTime(Request["StartDate"]) : new DateTime(); } }
        DateTime EndDate { get { return !string.IsNullOrEmpty(Request["EndDate"]) ? Convert.ToDateTime(Request["EndDate"]) : new DateTime(); } }

        XtraSchedulerReport CreateSchedulerReport() {
            XtraSchedulerReport report = new XtraSchedulerReport();
            var printAdapter = SchedulerExtension.GetPrintAdapter(SchedulerDemoHelper.ReportTemplatesSchedulerSettings,
                SchedulerDataHelper.DataObject.Appointments, SchedulerDataHelper.DataObject.Resources);
            printAdapter.EnableSmartSync = ReportTemplateFileName.ToLower().Contains("trifold");
            report.SchedulerAdapter = printAdapter.SchedulerAdapter;
            report.LoadLayout(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/SchedulerReportTemplates/" + ReportTemplateFileName));
            return report;
        }
        TimeInterval GetPrintTimeInterval() {
            return (StartDate <= EndDate) ? new TimeInterval(StartDate, EndDate) : new TimeInterval(EndDate, StartDate);
        }
    }
}
