using System;
using System.Threading;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class NavBarController: DemoController {
        public override string Name { get { return "NavBar"; } }

        public ActionResult Index() {
            return DataBinding();
        }
    }

    public class NavBarFeaturesDemoOptions {
        public NavBarFeaturesDemoOptions() {
            AllowExpanding = true;
            AllowSelectItem = true;
            AutoCollapse = true;
            EnableHotTrack = true;
            EnableAnimation = true;
            SaveStateToCookies = true;
        }

        public bool AllowExpanding { get; set; }
        public bool AllowSelectItem { get; set; }
        public bool AutoCollapse { get; set; }
        public bool EnableAnimation { get; set; }
        public bool EnableHotTrack { get; set; }
        public bool SaveStateToCookies { get; set; }
    }
}
