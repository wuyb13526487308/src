using System;
using System.Collections.Generic;
using System.Web;
using System.Xml.Serialization;

namespace DevExpress.Web.Demos {

    public class DemoModelBase {
        string _key;
        string _title;
        string _seoTitle;
        bool _isNew;
        bool _isUpdated;
       
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

        [XmlAttribute]
        public bool IsNew {
            get { return _isNew; }
            set { _isNew = value; }
        }

        [XmlAttribute]
        public bool IsUpdated {
            get { return _isUpdated; }
            set { _isUpdated = value; }
        }

    }

}
