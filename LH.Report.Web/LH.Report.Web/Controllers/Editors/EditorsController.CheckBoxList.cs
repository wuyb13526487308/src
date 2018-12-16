using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace DevExpress.Web.Demos {
    public partial class EditorsController : DemoController {
        [HttpGet]
        public ActionResult CheckBoxList() {
            ViewData["Options"] = new CheckListDemoOptions();
            return DemoView("CheckBoxList");
        }
        [HttpPost]
        public ActionResult CheckBoxList([Bind]CheckListDemoOptions options) {
            ViewData["Options"] = options;
            return DemoView("CheckBoxList");
        }
    }

    public class CheckListDemoOptions {
        public const RepeatLayout DefaultRepeatLayout = RepeatLayout.Table;
        public const RepeatDirection DefaultRepeatDirection = RepeatDirection.Horizontal;
        public const int DefaultRepeatColumns = 5;

        public CheckListDemoOptions() {
            RepeatLayout = DefaultRepeatLayout;
            RepeatDirection = DefaultRepeatDirection;
            RepeatColumns = DefaultRepeatColumns;
        }

        public RepeatLayout RepeatLayout { get; set; }
        public RepeatDirection RepeatDirection { get; set; }
        public int RepeatColumns { get; set; }
    }

    public static class CheckListDemoHelper {
        public static List<SelectListItem> GetRepeatLayouts() {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = RepeatLayout.Table.ToString(), Value = RepeatLayout.Table.ToString(), Selected = true },
                new SelectListItem() { Text = RepeatLayout.Flow.ToString(), Value = RepeatLayout.Flow.ToString() }
            };
        }
        public static List<SelectListItem> GetRepeatDirections() {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = RepeatDirection.Horizontal.ToString(), Value = RepeatDirection.Horizontal.ToString(), Selected = true },
                new SelectListItem() { Text = RepeatDirection.Vertical.ToString(), Value = RepeatDirection.Vertical.ToString() }
            };
        }
        public static List<SelectListItem> GetRepeatColumns(){
            return new List<SelectListItem>(){
                new SelectListItem(){ Text = "1", Value = "1" },
                new SelectListItem(){ Text = "2", Value = "2" },
                new SelectListItem(){ Text = "3", Value = "3" },
                new SelectListItem(){ Text = "4", Value = "4" },
                new SelectListItem(){ Text = "5", Value = "5", Selected = true},
                new SelectListItem(){ Text = "6", Value = "6" }
            };
        }
    }
}
