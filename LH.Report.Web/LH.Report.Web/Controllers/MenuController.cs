using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DevExpress.Web.ASPxClasses;

namespace DevExpress.Web.Demos {
    public partial class MenuController: DemoController {
        public override string Name { get { return "Menu"; } }

        public ActionResult Index() {
            return DataBinding();
        }
    }

    public class MenuFeaturesDemoOptions {
        public const int DefaultAppearAfter = 300;
        public const int DefaultDisappearAfter = 500;
        public const int DefaultMaximumDisplayLevels = 0;

        public MenuFeaturesDemoOptions() {
            AllowSelectItem = true;
            EnableHotTrack = true;
            EnableAnimation = true;
            AppearAfter = DefaultAppearAfter;
            DisappearAfter = DefaultDisappearAfter;
            MaximumDisplayLevels = DefaultMaximumDisplayLevels;
        }

        public bool AllowSelectItem { get; set; }
        public bool EnableHotTrack { get; set; }
        public bool EnableAnimation { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Must be 0 or greater.")]
        public int AppearAfter { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Must be 0 or greater.")]
        public int DisappearAfter { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Must be 0 or greater.")]
        public int MaximumDisplayLevels { get; set; }
    }

    public class PopupMenuOptions {
        public const PopupAction DefaultPopupAction = PopupAction.LeftMouseClick;
        public const PopupHorizontalAlign DefaultPopupHorizontalAlign = PopupHorizontalAlign.OutsideRight;
        public const PopupVerticalAlign DefaultPopupVerticalAlign = PopupVerticalAlign.TopSides;
        public const string DefaultCheckedItemName = "";

        public PopupMenuOptions() {
            PopupAction = DefaultPopupAction;
            HorizontalAlign = DefaultPopupHorizontalAlign;
            VerticalAlign = DefaultPopupVerticalAlign;
            CheckedItemName = DefaultCheckedItemName;
        }

        public PopupAction PopupAction { get; set; }
        public PopupHorizontalAlign HorizontalAlign { get; set; }
        public PopupVerticalAlign VerticalAlign { get; set; }
        public string CheckedItemName { get; set; }
    }

    public static class PopupMenuDemoHelper {
        public static List<SelectListItem> GetPopupActions() {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = PopupAction.LeftMouseClick.ToString(), Value = PopupAction.LeftMouseClick.ToString(), Selected = true },
                new SelectListItem() { Text = PopupAction.RightMouseClick.ToString(), Value = PopupAction.RightMouseClick.ToString() },
                new SelectListItem() { Text = PopupAction.MouseOver.ToString(), Value = PopupAction.MouseOver.ToString() }   
            };
        }
        public static List<SelectListItem> GetPopupHorizontalAlignOptions() {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = PopupHorizontalAlign.NotSet.ToString(), Value = PopupHorizontalAlign.NotSet.ToString() },
                new SelectListItem() { Text = PopupHorizontalAlign.OutsideLeft.ToString(), Value = PopupHorizontalAlign.OutsideLeft.ToString() },
                new SelectListItem() { Text = PopupHorizontalAlign.LeftSides.ToString(), Value = PopupHorizontalAlign.LeftSides.ToString() },
                new SelectListItem() { Text = PopupHorizontalAlign.RightSides.ToString(), Value = PopupHorizontalAlign.RightSides.ToString() },
                new SelectListItem() { Text = PopupHorizontalAlign.OutsideRight.ToString(), Value = PopupHorizontalAlign.OutsideRight.ToString(), Selected = true }
            };
        }
        public static List<SelectListItem> GetPopupVerticalAlignOptions() {
            return new List<SelectListItem>() {
                new SelectListItem() { Text = PopupVerticalAlign.NotSet.ToString(), Value = PopupVerticalAlign.NotSet.ToString() },
                new SelectListItem() { Text = PopupVerticalAlign.Above.ToString(), Value = PopupVerticalAlign.Above.ToString() },
                new SelectListItem() { Text = PopupVerticalAlign.TopSides.ToString(), Value = PopupVerticalAlign.TopSides.ToString(), Selected = true },
                new SelectListItem() { Text = PopupVerticalAlign.BottomSides.ToString(), Value = PopupVerticalAlign.BottomSides.ToString() },
                new SelectListItem() { Text = PopupVerticalAlign.Below.ToString(), Value = PopupVerticalAlign.Below.ToString() }
            };
        }
    }
}
