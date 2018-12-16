using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class DockingController : DemoController {
        public ActionResult ClientSideEvents() {
            return ClientSideEventsDemoView(new string[]{
                "Init",
                "AfterFloat_for_Panel",
                "AfterFloat_for_Manager",
                "AfterDock_for_Panel",
                "AfterDock_for_Zone",             
                "AfterDock_for_Manager",
                "BeforeFloat_for_Panel",
                "BeforeFloat_for_Manager",
                "BeforeDock_for_Panel",
                "BeforeDock_for_Zone",
                "BeforeDock_for_Manager",
                "CloseUp_for_Panel",
                "PanelCloseUp_for_Manager",
                "EndDragging_for_Panel",
                "EndPanelDragging_for_Manager",
                "PopUp_for_Panel",
                "PanelPopUp_for_Manager",
                "StartDragging_for_Panel",
                "StartPanelDragging_for_Manager"
            });
        }
    }
}
