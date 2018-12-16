using DevExpress.Web.Mvc;
using LH.StoReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Coldairarrow.Web.Controllers
{
    public class ReportController : Controller
    {
        //public override string Name
        //{
        //    get { return "Report"; }
        //}

        public ActionResult ReportViewer(string reportID)
        {
            if (reportID == null) reportID = "";
            return View(ReportHelper.CreateModel(reportID));
        }

        public ActionResult ReportViewerPartial(string reportID)
        {
            return PartialView("ReportViewerPartial", ReportHelper.CreateModel(reportID));
        }

        public ActionResult ReportParametersPartial(string reportID)
        {
            return PartialView("ReportParametersPartial", ReportHelper.CreateModel(reportID));

        }

        public ActionResult ReportViewerExportTo(string reportID)
        {
            return ReportViewerExtension.ExportTo(ReportHelper.CreateModel(reportID).Report);
        }
    }
}