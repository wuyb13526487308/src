using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DevExpress.Web.Demos {

    public class DemoModel : DemoModelBase {        
        string _description;
        string _metaDescription;
        bool _hideSourceCode;        
        List<string> _sourceFiles = new List<string>();
        bool _ie7CompatModeRequired;

        int _highlightedIndex = -1;
        string _highlightedImageUrl;
        string _highlightedTitle;
        string _highlightedLink;

        DemoGroupModel _group;
        bool _descriptionProcessed;

        [XmlIgnore]
        public DemoGroupModel Group {
            get { return _group; }
            internal set { _group = value; }
        }

        [XmlAttribute]
        public virtual bool HideSourceCode {
            get { return _hideSourceCode; }
            set { _hideSourceCode = value; }
        }

        // Html is allowed here
        [XmlElement]
        public string Description {
            get {
                if(!_descriptionProcessed) {
                    _description = ProcessDescription(_description);
                    _descriptionProcessed = true;
                }
                return _description;
            }
            set {
                if(value != null)
                    value = value.Trim();
                _description = value;
            }
        }
        [XmlElement]
        public string MetaDescription {
            get {
                if(_metaDescription == null)
                    return "";
                return _metaDescription;
            }
            set {
                if(value != null)
                    value = value.Trim();
                _metaDescription = value;
            }
        }

        [XmlElement("SourceFile")]
        public List<string> SourceFiles {
            get { return _sourceFiles; }
        }

        [XmlAttribute]
        public int HighlightedIndex {
            get { return _highlightedIndex; }
            set { _highlightedIndex = value; }
        }

        [XmlAttribute]
        public string HighlightedImageUrl {
            get {
                if(_highlightedImageUrl == null)
                    return "";
                return _highlightedImageUrl;
            }
            set { _highlightedImageUrl = value; }
        }

        [XmlAttribute]
        public string HighlightedTitle {
            get {
                if(_highlightedTitle == null)
                    return "";
                return _highlightedTitle;
            }
            set { _highlightedTitle = value; }
        }

        [XmlAttribute]
        public string HighlightedLink {
            get { return _highlightedLink; }
            set { _highlightedLink = value; }
        }

        [XmlAttribute]
        public bool IE7CompatModeRequired {
            get { return _ie7CompatModeRequired; }
            set { _ie7CompatModeRequired = value; }
        }

        public string GetHighlightedTitle() {
            if(!String.IsNullOrEmpty(HighlightedTitle))
                return HighlightedTitle;
            return Title;
        }

        static string ProcessDescription(string text) {
            if(text == null)
                text = "";
            text = Regex.Replace(text, @"<code\s+lang=([^>]+)>(.*?)</code>", DescriptionCodeReplacer, RegexOptions.Singleline);
            return text;
        }

        static string DescriptionCodeReplacer(Match match) {
            string lang = match.Groups[1].Value.Trim('"', '\'');
            string code = match.Groups[2].Value;
            return "<code>" + CodeFormatter.GetFormattedCode(CodeFormatter.ParseLanguage(lang), code) + "<br /></code>";
        }

        public string GetSeoTitle() {
            if(!String.IsNullOrEmpty(SeoTitle))
                return SeoTitle;
            return Title;
        }

    }

}
