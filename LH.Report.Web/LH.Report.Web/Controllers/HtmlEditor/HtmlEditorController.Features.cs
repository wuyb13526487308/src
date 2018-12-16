using System.Web.Mvc;
using DevExpress.Web.ASPxHtmlEditor;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class HtmlEditorController : DemoController {
        [HttpGet]
        public ActionResult Features() {
            ViewData["ActiveView"] = HtmlEditorView.Design;
            ViewData["Html"] = @"<div style='font-size: 10pt'><p align='center'><font size='5' style='font-weight: bold;'>Soviets Launch First Man in Space</font><br><font style='color: rgb(128, 128, 128);' size='2'>4/12/1961</font><br><img src='../Content/HtmlEditor/Images/Gagarin.jpg' alt='Image' style='margin: 1em 1em 0pt 0pt; width: 150px; height: 113px; float: left;'></p>Major Yuri Alexeyevich Gagarin was fired from the Baikonur launch pad in Kazakhstan, Soviet central Asia, in the space craft Vostok (East). Gagarin orbited the Earth for 108 minutes travelling at more than 17,000 miles per hour (27,000 kilometres per hour) before landing at an undisclosed location. The Soviet leader Nikita Khrushchev has congratulated Major Gagarin on his achievement. He sent the cosmonaut a message from his holiday home on the Black Sea. 'The flight made by you opens up a new page in the history of mankind in its conquest of space,' Mr.Khrushchev said. The Soviet news agency, Tass, made the first official announcement of Major Gagarin's flight at just before 0800BST.<div>";
            Session["Options"] = new HtmlEditorFeaturesDemoOptions();
            return DemoView("Features");
        }
        [HttpPost]
        public ActionResult Features([Bind]HtmlEditorFeaturesDemoOptions options) {
            ViewData["ActiveView"] = HtmlEditorExtension.GetActiveView("heFeatures");
            ViewData["Html"] = HtmlEditorExtension.GetHtml("heFeatures",
                new ASPxHtmlEditorHtmlEditingSettings {
                    AllowFormElements = options.AllowFormElements,
                    AllowIFrames = options.AllowIFrames,
                    AllowScripts = options.AllowScripts,
                    EnterMode = options.EnterMode,
                    UpdateBoldItalic = options.UpdateBoldItalic,
                    UpdateDeprecatedElements = options.UpdateDeprecatedElements
                });
            Session["Options"] = options;
            return DemoView("Features");
        }
        public ActionResult FeaturesPartial() {
            return PartialView("FeaturesPartial");
        }
        public ActionResult FeaturesImageUpload() {
            HtmlEditorExtension.SaveUploadedImage("heFeatures", HtmlEditorDemosHelper.ImageUploadValidationSettings, HtmlEditorDemosHelper.UploadDirectory);
            return null;
        }
        public ActionResult FeaturesImageSelectorUpload() {
            HtmlEditorExtension.SaveUploadedImage("heFeatures", HtmlEditorDemosHelper.ImageSelectorSettings);
            return null;
        }
    }
}
