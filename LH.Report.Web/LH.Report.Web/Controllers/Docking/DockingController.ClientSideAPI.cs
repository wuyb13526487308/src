using System.Collections.Generic;
using System.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class DockingController : DemoController {
        public ActionResult ClientSideAPI() {
            return DemoView("ClientSideAPI");
        }
    }

    public class ClientSideAPIDemoHelper {
        public static List<SelectListItem> GetPanelUIDs() {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = "2D Pie", Value = "panel1", Selected = true },
                new SelectListItem() { Text = "3D Bubble", Value = "panel2" },
                new SelectListItem() { Text = "3D Bar", Value = "panel3" },
                new SelectListItem() { Text = "2D Bubble", Value = "panel4" }  
            };
        }
        public static List<SelectListItem> GetZoneUIDs() {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = "None", Value = "none", Selected = true },
                new SelectListItem() { Text = "Left zone", Value = "zone1" },
                new SelectListItem() { Text = "Right zone", Value = "zone2" }
            };
        }
        public static List<int> GetVisibleIndices() {
            return new List<int>() { 0, 1, 2, 3 };
        }
    }
}
