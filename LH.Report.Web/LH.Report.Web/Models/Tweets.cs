using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Xml;

namespace DevExpress.Web.Demos {

    public class Tweet {
        public DateTime Date { get; set; }        
        public string Text { get; set; }
    }

    public static class TweetProvider {

        public static IList GetDevExpressTweets() {
            try {
                return ConvertTimeline(MakeApiCall("https://api.twitter.com/1/statuses/user_timeline.json?screen_name=devexpress"));
            }
            catch {
                return Utils.IsSiteMode ? LoadTweetsFromFile(HttpContext.Current.Server.MapPath("~/App_Data/Tweets.xml")) : new List<Tweet>();
            }
        }

        static object MakeApiCall(string url) {
            var req = HttpWebRequest.Create(url);
            using(var stream = req.GetResponse().GetResponseStream())
            using(var reader = new StreamReader(stream, Encoding.UTF8)) {
                return new JavaScriptSerializer().DeserializeObject(reader.ReadToEnd());
            }
        }

        static IList ConvertTimeline(dynamic raw) {
            return (raw as IList).Cast<dynamic>().Select(tuplet => new Tweet {
                Date = ParseDate(tuplet["created_at"]),
                Text = Convert.ToString(tuplet["text"])
            }).ToList();
        }

        static DateTime ParseDate(dynamic raw) {
            return DateTime.ParseExact(raw, "ddd MMM dd HH:mm:ss zzz yyyy", null);
        }

        static IList LoadTweetsFromFile(string path) {
            List<Tweet> tweets = new List<Tweet>();
            Random random = new Random();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            foreach (XmlNode node in xmlDocument.SelectNodes("//Tweets/Tweet")) {
                TimeSpan differrenceDate = TimeSpan.FromDays(-random.Next(3));
                tweets.Add(new Tweet() { Date = DateTime.Today.Add(differrenceDate), Text = node.InnerText });
            }
            return tweets;
        }
    }
}
