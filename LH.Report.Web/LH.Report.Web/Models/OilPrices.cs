using System;
using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class OilPricesProvider {
        public const string ANSWestCoast = "ANS West Coast";
        public const string WestTexasIntermediate = "West Texas Intermediate";

        public static IList<StateOilPrices> GetOilPrices() {
            List<StateOilPrices> oilPrices = new List<StateOilPrices>();
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 1, 1), 36, 43.29));
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 2, 1), 40.68, 47.07));
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 3, 1), 45.01, 52.77));
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 4, 1), 45.99, 54.14));
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 5, 1), 43.73, 49.03));
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 6, 1), 49.94, 57.94));
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 7, 1), 52.88, 58.98));
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 8, 1), 58.81, 67.06));
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 9, 1), 61, 66.72));
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 10, 1), 57.86, 63.47));
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 11, 1), 54.24, 59.98));
            oilPrices.Add(new StateOilPrices(ANSWestCoast, new DateTime(2005, 12, 1), 55.22, 59.22));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 1, 1), 42.12, 49.91));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 2, 1), 28.33, 51.75));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 3, 1), 48.96, 56.72));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 4, 1), 49.72, 57.27));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 5, 1), 46.8, 52.07));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 6, 1), 52.54, 60.54));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 7, 1), 54.93, 61.28));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 8, 1), 60.86, 68.94));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 9, 1), 63, 69.47));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 10, 1), 59.76, 65.47));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 11, 1), 56.14, 61.78));
            oilPrices.Add(new StateOilPrices(WestTexasIntermediate, new DateTime(2005, 12, 1), 57.34, 61.37));
            return oilPrices;
        }
    }

    public class StateOilPrices {
        DateTime date;
        string company;
        double minPrice;
        double maxPrice;

        public DateTime Date { get { return date; } }
        public string Company { get { return company; } }
        public double MinPrice { get { return minPrice; } }
        public double MaxPrice { get { return maxPrice; } }

        public StateOilPrices(string company, DateTime date, double minPrice, double maxPrice) {
            this.date = date;
            this.company = company;
            this.minPrice = minPrice;
            this.maxPrice = maxPrice;
        }
    }
}
