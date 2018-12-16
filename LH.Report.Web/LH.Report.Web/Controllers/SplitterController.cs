using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class SplitterController: DemoController {
        public override string Name { get { return "Splitter"; } }

        public ActionResult Index() {
            return Resizing();
        }
    }
}
