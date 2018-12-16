using System.Collections.Generic;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult FormattingRulesReport([ModelBinder(typeof(ParameterDictionaryBinder))] Dictionary<string, string> parameter) {
            var model = ReportDemoHelper.CreateModel("FormattingRules", parameter);
            ViewData["parameterConditionIndexParameter"] = SelectListItemHelper.GetFormattingRuleConditionItems((int)model.Report.Parameters["ConditionIndexParameter"].Value);
            ViewData["parameterStyleIndexParameter"] = SelectListItemHelper.GetFormattingRuleStyleItems((int)model.Report.Parameters["StyleIndexParameter"].Value);
            return DemoView("FormattingRulesReport", "SampleViewer", model);
        }
    }
}
