using System.Web.Mvc;
using DevExpress.Web.Demos;
using System.Xml;
using System;
using System.Collections.Generic;
using System.Web;
using DevExpress.Web.Mvc;

namespace DevExpress.Web.Demos {
    public partial class EditorsController : DemoController {
        public ActionResult Calendar() {
            return DemoView("Calendar");
        }
        public ActionResult CalendarPartial() {
            return PartialView("CalendarPartial");
        }
        public ActionResult CalendarPopupPartial() {
            if (!string.IsNullOrEmpty(Request.Params["DateString"]))
                ViewData["PopupContent"] = new CalendarDemoHelper(Server.MapPath("~/App_Data/CalendarNotes.xml")).GetNote(Request.Params["DateString"]);
            return PartialView("CalendarPopupPartial");
        }
    }

    public class CalendarDemoHelper {
        XmlDocument xml;

        public CalendarDemoHelper(string xmlPath) {
            this.xml = new XmlDocument();
            this.xml.Load(xmlPath);
        }
        public string GetDateString(DateTime date) {
            return date.ToString("M/d/yyyy", System.Globalization.CultureInfo.InvariantCulture);
        }
        public string GetNote(string dateString) {
            List<string> list = new List<string>();
            foreach (XmlNode node in GetNoteNodes(dateString)) {
                list.Add(HttpUtility.HtmlEncode(node.Attributes["Text"].Value));
            }
            return String.Join("<br/><br/>", list.ToArray());
        }
        public XmlNodeList GetNoteNodes(DateTime date) {
            return GetNoteNodes(GetDateString(date));
        }

        XmlDocument Xml { get { return xml; } }
        XmlNodeList GetNoteNodes(string dateString) {
            return Xml.SelectNodes(string.Format("//Notes/Note[@Date='{0}']", dateString));
        }
    }
}
