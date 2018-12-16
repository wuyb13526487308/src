using System.Collections.Generic;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult SideBySideReport([Bind(Prefix="parameter_")][ModelBinder(typeof(ParameterDictionaryBinder))] Dictionary<string, string> parameter) {
            var model = ReportDemoHelper.CreateModel("SideBySide", parameter);
            ViewData["parameter_leftSideParameter"] = SelectListItemHelper.GetSideBySideItems((int)model.Report.Parameters["leftSideParameter"].Value);
            ViewData["parameter_rightSideParameter"] = SelectListItemHelper.GetSideBySideItems((int)model.Report.Parameters["rightSideParameter"].Value);
            return DemoView("SideBySideReport", "SampleViewer", model);
        }
    }
}
