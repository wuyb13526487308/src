using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class CorporationsMarketValueProvider {
        public static IList<CorporationsMarketValue> GetCorporationsMarketValue() {
            string[] corporations = new string[] { "ExxonMobil", "General Electric", "Microsoft", "Citigroup",
                "Royal Dutch Shell plc", "Procter & Gamble" };
            string[] years = new string[] { "2004", "2005" };
            Dictionary<string, double[]> marketValues = new Dictionary<string, double[]>();
            marketValues.Add(years[0], new double[] { 277.02, 328.54, 297.02, 255.3, 173.54, 131.89 });
            marketValues.Add(years[1], new double[] { 362.53, 348.45, 279.02, 230.93, 203.52, 197.12 });

            List<CorporationsMarketValue> result = new List<CorporationsMarketValue>();
            foreach (string year in years)
                for (int i = 0; i < corporations.Length; i++)
                    result.Add(new CorporationsMarketValue(corporations[i], year, marketValues[year][i]));
            return result;
        }
    }

    public class CorporationsMarketValue {
        string corporation;
        string year;
        double marketValue;

        public string Corporation { get { return corporation; } }
        public string Year { get { return year; } }
        public double MarketValue { get { return marketValue; } }

        public CorporationsMarketValue(string corporation, string year, double marketValue) {
            this.corporation = corporation;
            this.year = year;
            this.marketValue = marketValue;
        }
    }
}
