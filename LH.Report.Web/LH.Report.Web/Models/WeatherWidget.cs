using System;
using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class WeatherWidget {
        public static List<DayControl> GetDayControls() {
            return new List<DayControl>() {
                new DayControl("Tu", "../Content/Docking/Images/Widgets/Weather/rain_common.png", "+2°|-1°"), 
                new DayControl("We", "../Content/Docking/Images/Widgets/Weather/cloudiness_hi.png", "+4°| 0°"),
                new DayControl("Th", "../Content/Docking/Images/Widgets/Weather/cloudiness_partly.png", "+5°|+1°"),
                new DayControl("Fr", "../Content/Docking/Images/Widgets/Weather/cloudiness_low.png", "+7°|+3°")
            };
        }
    }

    public class DayControl {
        string dayOfWeekHyperLinkText;
        string weatherImageUrl;
        string temperatureHyperLinkText;

        public DayControl(string dayOfWeekHyperLinkText, string weatherImageUrl, string temperatureHyperLinkText) {
            this.dayOfWeekHyperLinkText = dayOfWeekHyperLinkText;
            this.weatherImageUrl = weatherImageUrl;
            this.temperatureHyperLinkText = temperatureHyperLinkText;
        }

        public string DayOfWeek {
            get { return dayOfWeekHyperLinkText; }
        }

        public string WeatherImageUrl {
            get { return weatherImageUrl; }
        }

        public string Temperature {
            get { return temperatureHyperLinkText; }
        }
    }
}
