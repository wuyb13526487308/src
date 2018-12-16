using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class WebSiteVisitorsProvider {
        public static IList<WebSiteWisitors> GetWebSiteVisitors() {
            return new List<WebSiteWisitors>() {
                new WebSiteWisitors("Visited a Web Site", 9152),
                new WebSiteWisitors("Downloaded a Trial", 6870),
                new WebSiteWisitors("Contacted to Support", 5121),
                new WebSiteWisitors("Subscribed", 2224),
                new WebSiteWisitors("Renewed", 1670)
            };
        }
    }

    public class WebSiteWisitors {
        string caption;
        int count;

        public string Caption { get { return caption; } }
        public int Count { get { return count; } }

        public WebSiteWisitors(string caption, int count) {
            this.caption = caption;
            this.count = count;
        }
    }
}
