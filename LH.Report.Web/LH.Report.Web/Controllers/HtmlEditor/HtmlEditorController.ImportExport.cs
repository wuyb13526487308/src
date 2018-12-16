using System.Web.Mvc;
using DevExpress.Web.ASPxHtmlEditor;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class HtmlEditorController : DemoController {
        const string SampleDocumentPath = "~/Content/HtmlEditor/SampleImportDocument.rtf";

        public ActionResult ImportExport() {
            ViewData["SampleDocumentPath"] = SampleDocumentPath;
            string htmlContentPath = Server.MapPath("~/Content/HtmlEditor/DemoHtml/ImportExport.htm");
            string html = System.IO.File.ReadAllText(htmlContentPath);
            return DemoView("ImportExport", "ImportExport", new HtmlEditorModel(html));
        }
        public ActionResult ImportExportPartial() {
            return PartialView("ImportExportPartial");
        }
        public ActionResult ExportTo(HtmlEditorExportFormat format) {
            return HtmlEditorExtension.Export(
                HtmlEditorDemosHelper.SetHtmlEditorExportSettings(new HtmlEditorSettings()),
                format
            );
        }
        public ActionResult ImportSampleDocument() {
            ViewData["SampleDocumentPath"] = SampleDocumentPath;
            HtmlEditorModel model = null;
            HtmlEditorExtension.Import(
                "~/Content/HtmlEditor/SampleImportDocument.rtf",
                HtmlEditorDemosHelper.ImportContentDirectory,
                (html, cssFiles) => model = new HtmlEditorModel(html, cssFiles)
            );
            return DemoView("ImportExport", "ImportExport", model);
        }
    }
}
