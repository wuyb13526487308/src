using System;
using System.Threading;
using System.Web.Mvc;
using DevExpress.Web.ASPxTabControl;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class TabControlController: DemoController {
        public override string Name { get { return "TabControl"; } }

        public ActionResult Index() {
            return DataBindingToXML();
        }
    }

    public class TabControlFeaturesDemoOptions {
        public TabControlFeaturesDemoOptions() {
            ActivateTabPageAction = ActivateTabPageAction.Click;
            EnableHotTrack = true;
            SaveStateToCookies = true;
            TabAlign = TabAlign.Left;
            TabPosition = TabPosition.Top;
        }

        public ActivateTabPageAction ActivateTabPageAction { get; set; }
        public bool EnableHotTrack { get; set; }
        public bool SaveStateToCookies { get; set; }
        public TabAlign TabAlign { get; set; }
        public TabPosition TabPosition { get; set; }
    }
}
