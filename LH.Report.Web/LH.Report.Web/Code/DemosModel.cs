using System.Xml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace DevExpress.Web.Demos {

    [XmlRoot("Demos")]
    public class DemosModel {
        static DemosModel _current;
        static readonly object _currentLock = new object();

        public static DemosModel Current {
            get {
                lock(_currentLock) {
                    if(_current == null) {
                        using(Stream stream = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/Demos.xml"))) {
                            XmlSerializer serializer = new XmlSerializer(typeof(DemosModel));
                            _current = (DemosModel)serializer.Deserialize(stream);
                        }
                        foreach(DemoGroupModel group in _current.Groups) {
                            foreach(DemoModel demo in group.Demos)
                                demo.Group = group;
                        }
                    }
                    return _current;
                }
            }
        }

        bool _isMvc;
        bool _isMvcRazor;
        bool _isRootDemo;
        string _key;
        string _title;
        string _seoTitle;
        bool _ie7CompatModeRequired;
        bool _supportsTheming = true;
        List<DemoGroupModel> _groups = new List<DemoGroupModel>();

        string _learnMoreUrl;
        string _downloadUrl;
        string _buyUrl;
        string _videosUrl;
        string _docUrl;

        List<DemoModel> _highlighledDemos;

        [XmlAttribute]
        public bool IsMvc {
            get { return _isMvc; }
            set { _isMvc = value; }
        }

        [XmlAttribute]
        public bool IsMvcRazor {
            get { return _isMvcRazor; }
            set { _isMvcRazor = value; }
        }

        [XmlAttribute]
        public bool IsRootDemo {
            get { return _isRootDemo; }
            set { _isRootDemo = value; }
        }

        [XmlAttribute]
        public string Key {
            get {
                if(_key == null)
                    return "";
                return _key;
            }
            set { _key = value; }
        }

        [XmlAttribute]
        public string Title {
            get {
                if(_title == null)
                    return "";
                return _title;
            }
            set { _title = value; }
        }

        [XmlAttribute]
        public string SeoTitle {
            get {
                if(_seoTitle == null)
                    return "";
                return _seoTitle;
            }
            set { _seoTitle = value; }
        }

        [XmlElement]
        public string LearnMoreUrl {
            get {
                if(_learnMoreUrl == null)
                    return "";
                return _learnMoreUrl;
            }
            set {
                if(value != null)
                    value = value.Trim();
                _learnMoreUrl = value;
            }
        }

        [XmlElement]
        public string DownloadUrl {
            get {
                if(_downloadUrl == null)
                    return "";
                return _downloadUrl;
            }
            set {
                if(value != null)
                    value = value.Trim();
                _downloadUrl = value;
            }
        }

        [XmlElement]
        public string BuyUrl {
            get {
                if(_buyUrl == null)
                    return "";
                return _buyUrl;
            }
            set {
                if(value != null)
                    value = value.Trim();
                _buyUrl = value;
            }
        }

        [XmlElement]
        public string VideosUrl {
            get {
                if(_videosUrl == null)
                    return "";
                return _videosUrl;
            }
            set {
                if(value != null)
                    value = value.Trim();
                _videosUrl = value;
            }
        }

        [XmlElement]
        public string DocUrl {
            get {
                if(_docUrl == null)
                    return "";
                return _docUrl;
            }
            set {
                if(value != null)
                    value = value.Trim();
                _docUrl = value;
            }
        }

        [XmlElement("DemoGroup")]
        public List<DemoGroupModel> Groups {
            get { return _groups; }
        }

        [XmlAttribute]
        public bool IE7CompatModeRequired {
            get { return _ie7CompatModeRequired; }
            set { _ie7CompatModeRequired = value; }
        }

        [XmlAttribute]
        public bool SupportsTheming {
            get { return _supportsTheming; }
            set { _supportsTheming = value; }
        }

        [XmlIgnore]
        public List<DemoModel> HighlightedDemos {
            get {
                if(_highlighledDemos == null)
                    _highlighledDemos = CreateHighlightedDemos();
                return _highlighledDemos;
            }
        }


        public DemoGroupModel FindGroup(string key) {
            key = key.ToLower();
            foreach(DemoGroupModel group in Groups) {
                if(key == group.Key.ToLower())
                    return group;
            }
            return null;
        }

        List<DemoModel> CreateHighlightedDemos() {
            List<DemoModel> result = new List<DemoModel>();
            foreach(DemoGroupModel group in Groups) {
                foreach(DemoModel demo in group.Demos) {
                    if(demo.HighlightedIndex > -1)
                        result.Add(demo);
                }
            }
            result.Sort(CompareHighlightedDemos);
            return result;
        }

        int CompareHighlightedDemos(DemoModel x, DemoModel y) {
            return Comparer<int>.Default.Compare(x.HighlightedIndex, y.HighlightedIndex);
        }

        public string GetSeoTitle() {
            if(!string.IsNullOrEmpty(SeoTitle))
                return SeoTitle;
            return Title;
        }
    }

}
