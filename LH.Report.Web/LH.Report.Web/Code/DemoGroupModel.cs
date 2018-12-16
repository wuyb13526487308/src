using System.Xml.Serialization;
using System.Collections.Generic;

namespace DevExpress.Web.Demos {

    public class DemoGroupModel : DemoModelBase {
        List<DemoModel> _demos = new List<DemoModel>();

        [XmlElement(Type = typeof(IntroPageModel), ElementName = "Intro")]
        [XmlElement(Type = typeof(DemoModel), ElementName = "Demo")]
        public List<DemoModel> Demos {
            get { return _demos; }
        }

        public DemoModel FindDemo(string key) {
            key = key.ToLower();
            foreach(DemoModel demo in Demos) {
                if(key == demo.Key.ToLower())
                    return demo;
            }
            return null;
        }

    }

}
