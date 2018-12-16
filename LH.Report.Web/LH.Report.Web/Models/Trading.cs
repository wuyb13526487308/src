using System;
using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class Trading {
        public static List<CurrencyRate> GetCurrencyRates() {
            return new List<CurrencyRate> {
                new CurrencyRate("EUR", Convert.ToSingle(1.3932), Convert.ToSingle(-0.0014)),
                new CurrencyRate("RUR", Convert.ToSingle(0.0348), Convert.ToSingle(-0.0001))
            };
        }

        public static List<MarketLeader> GetMarketLeaders() {
            return new List<MarketLeader> {
                new MarketLeader("APDSP", "41.56", "14.61%"),
                new MarketLeader("MGNZ", "53.91", "10.63%"),
                new MarketLeader("APDS", "87.55", "9.54%"),
                new MarketLeader("MAGE", "0.09", "7.92%"),
                new MarketLeader("VOSB", "0.90", "7.87%"),
                new MarketLeader("DASPA", "20.96", "4.2%"),
                new MarketLeader("HASO", "42.11", "12.1%"),
                new MarketLeader("VIGE", "12.23", "8.2%"),
                new MarketLeader("MERG", "10.1", "1.9%"),
                new MarketLeader("TROM", "12.2", "12.14%")
            };
        }
    }

    public class CurrencyRate {
        string currency;
        float value;
        float growth;

        public CurrencyRate(string currency, float value, float growth) {
            this.currency = currency;
            this.value = value;
            this.growth = growth;
        }

        public string Currency {
            get { return currency; }
        }

        public float Value {
            get { return value; }
        }

        public float Growth {
            get { return growth; }
        }
    }

    public class MarketLeader {
        string index;
        string value;
        string growth;

        public MarketLeader(string index, string value, string growth) {
            this.index = index;
            this.value = value;
            this.growth = growth;
        }

        public string Index {
            get { return index; }
        }

        public string Value {
            get { return value; }
        }

        public string Growth {
            get { return growth; }
        }
    }
}
