using System.Collections.Generic;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class ReportController : DemoController {
        public ActionResult TableReport([ModelBinder(typeof(ParameterDictionaryBinder))] Dictionary<string, string> parameter) {
            return DemoView("TableReport", "SampleViewer", ReportDemoHelper.CreateModel("Table", parameter));
        }
    }
}
