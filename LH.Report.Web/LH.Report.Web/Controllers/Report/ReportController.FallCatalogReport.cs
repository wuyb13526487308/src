using System.Collections.Generic;
using System.Web.Mvc;
using DevExpress.XtraReports.UI;
using XtraReportsDemos.NorthwindTraders;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult FallCatalogReport([Bind(Prefix="report_")][ModelBinder(typeof(ParameterDictionaryBinder))] Dictionary<string, string> parameter) {
            var model = ReportDemoHelper.CreateModel("FallCatalog", parameter);
            ViewData["report_parameterSortGroupsType"] = SelectListItemHelper.Generate((SortGroupsType)model.Report.Parameters["parameterSortGroupsType"].Value);
            ViewData["report_parameterSortGroupsOrder"] = SelectListItemHelper.Generate((XRColumnSortOrder)model.Report.Parameters["parameterSortGroupsOrder"].Value);
            return DemoView("FallCatalogReport", "SampleViewer", model);
        }
    }
}
