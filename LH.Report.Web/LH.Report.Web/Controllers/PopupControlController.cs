using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxPopupControl;

namespace DevExpress.Web.Demos {
    public partial class PopupControlController: DemoController {
        public override string Name { get { return "PopupControl"; } }

        public ActionResult Index() {
            return DataBinding();
        }
    }

    public class PopupControlFeaturesDemoOptions {
        public const int DefaultOpacity = 100;
        public const int DefaultAppearAfter = 300;
        public const int DefaultDisappearAfter = 500;

        public PopupControlFeaturesDemoOptions() {
            ShowCloseButton = true;
            ShowShadow = true;
            ShowFooter = true;
            ShowHeader = true;
            PopupHorizontalAlign = PopupHorizontalAlign.LeftSides;
            PopupVerticalAlign = PopupVerticalAlign.Below;
            PopupHorizontalOffset = 0;
            PopupVerticalOffset = 0;
            Opacity = DefaultOpacity;
            PopupAnimationType = AnimationType.Slide;
            AllowDragging = false;
            DragElement = DragElement.Header;
            AllowResize = false;
            ResizingMode = ResizingMode.Live;
            ShowSizeGrip = ShowSizeGrip.Auto;
            CloseAction = CloseAction.OuterMouseClick;
            PopupAction = PopupAction.LeftMouseClick;
            AppearAfter = DefaultAppearAfter;
            DisappearAfter = DefaultDisappearAfter;
            ScrollBars = ScrollBars.None;
        }

        public bool ShowCloseButton { get; set; }
        public bool ShowShadow { get; set; }
        public bool ShowFooter { get; set; }
        public bool ShowHeader { get; set; }
        public PopupHorizontalAlign PopupHorizontalAlign { get; set; }
        public PopupVerticalAlign PopupVerticalAlign { get; set; }
        public int PopupHorizontalOffset { get; set; }
        public int PopupVerticalOffset { get; set; }
        [Range(0, 100, ErrorMessage = "Must be between 0 and 100.")]
        public int Opacity { get; set; }
        public AnimationType PopupAnimationType { get; set; }
        public bool AllowDragging { get; set; }
        public DragElement DragElement { get; set; }
        public bool AllowResize { get; set; }
        public ResizingMode ResizingMode { get; set; }
        public ShowSizeGrip ShowSizeGrip { get; set; }
        public CloseAction CloseAction { get; set; }
        public PopupAction PopupAction { get; set; }
        public ScrollBars ScrollBars { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Must be 0 or greater.")]
        public int AppearAfter { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Must be 0 or greater.")]
        public int DisappearAfter { get; set; }
    }
}
