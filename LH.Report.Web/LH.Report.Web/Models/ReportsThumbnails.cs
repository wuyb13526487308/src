using System;
using DevExpress.Utils;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.Web;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Drawing.Imaging;
using System.Drawing;
using System.Web.UI.WebControls;

namespace DevExpress.Web.Demos {
    public delegate IEnumerable<EmployeeThumbnail> GenerateEmployeesDelegate(string reportViewerName);

    public class EmployeeThumbnail {
        public static EmployeeThumbnail CreateRoot() {
            return new EmployeeThumbnail() { IsRoot = true };
        }

        public bool IsRoot { get; private set; }
        public string ImageFileName { get; set; }
        public string Text { get; set; }
        public string NavigationScript { get; set; }
        public Unit Width { get; set; }
        public Unit Height { get; set; }
        public Color BorderColor { get; set; }
        public Unit BorderWidth { get; set; }
        public IList<EmployeeThumbnail> Items { get; private set; }

        public EmployeeThumbnail() {
            Items = new List<EmployeeThumbnail>();
        }
    }

    public class ThumbnailsBookmarkFiller : BookmarkFillerBase<EmployeeThumbnail> {
        public static IEnumerable<EmployeeThumbnail> GetItems(XtraReport report, string reportViewerName) {
            if(report.PrintingSystem.Document.PageCount == 0)
                report.CreateDocument(false);
            var root = EmployeeThumbnail.CreateRoot();
            new ThumbnailsBookmarkFiller(report.PrintingSystem.Document, reportViewerName).Fill(root);
            return root.Items[0].Items;
        }

        readonly Document document;
        
        public ThumbnailsBookmarkFiller(Document document, string reportViewerName)
            : base(reportViewerName) {
            this.document = document;
	    }

        protected override Document  Document {
            get { return document; }
        }

        protected override EmployeeThumbnail FillNode(EmployeeThumbnail parent, BookmarkNode bookmarkNode, string navigationScript) {
            var imageBrick = bookmarkNode.Brick as ImageBrick;
            if(imageBrick == null && !parent.IsRoot)
                return null;
            var result = new EmployeeThumbnail();
            if(imageBrick != null) {
                string fileName = bookmarkNode.Text + ".png";
                string filePath = HttpContext.Current.Server.MapPath("~/App_Data/Thumbnails/" + fileName);
                if(!Directory.Exists(Path.GetDirectoryName(filePath)))
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                if(!File.Exists(filePath))
                    imageBrick.Image.Save(filePath, ImageFormat.Png);
                result.ImageFileName = fileName;
                result.Text = bookmarkNode.Text;
                result.NavigationScript = navigationScript;
                result.Width = Unit.Pixel(imageBrick.Image.Width / 2);
                result.Height = Unit.Pixel(imageBrick.Image.Height / 2);
                result.BorderColor = imageBrick.BorderColor;
                result.BorderWidth = Unit.Pixel((int)imageBrick.BorderWidth);
            }
            parent.Items.Add(result);
            return result;
        }
    }
}
