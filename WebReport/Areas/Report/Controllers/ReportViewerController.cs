using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebReport.Areas.Report.Controllers
{
    public class ReportViewerController : Controller
    {
        //
        // GET: /Report/ReportViewer/

        public ActionResult Index()
        {
            return View();
        }

    }
}
