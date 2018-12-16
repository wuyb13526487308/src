using DevExpress.Web.Mvc;
using LH.StoReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevExpress.Web.Demos.Areas.LHReport.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /LHReport/Report/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportViewer(string reportID)
        {
            if (reportID == null) reportID = "";
            return View(LHReportHelper.CreateModel(reportID));
        }

        public ActionResult ReportViewerPartial(string reportID)
        {
            return PartialView("ReportViewerPartial", LHReportHelper.CreateModel(reportID));
        }

        public ActionResult ReportParametersPartial(string reportID)
        {
            return PartialView("ReportParametersPartial", LHReportHelper.CreateModel(reportID));

        }

        public ActionResult ReportViewerExportTo(string reportID)
        {
            return ReportViewerExtension.ExportTo(LHReportHelper.CreateModel(reportID).Report);
        }


    }
}
