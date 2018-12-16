using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class MicrosoftAnnualRevenueProvider {
        public static List<RevenueEntry> GetMicrosoftAnnualRevenue() {
            return new List<RevenueEntry>() {
                new RevenueEntry("2000", 22.96, 22.96),
                new RevenueEntry("2001", 25.3, 48.25),
                new RevenueEntry("2002", 28.36, 76.62),
                new RevenueEntry("2003", 32.19, 108.8),
                new RevenueEntry("2004", 36.83, 145.54)
            };
        }
    }

    public class RevenueEntry {
        string year;
        double annualRevenue;
        double summaryRevenue;

        public string Year { get { return year; } }
        public double AnnualRevenue { get { return annualRevenue; } }
        public double SummaryRevenue { get { return summaryRevenue; } }

        public RevenueEntry(string year, double annualRevenue, double summaryRevenue) {
            this.year = year;
            this.annualRevenue = annualRevenue;
            this.summaryRevenue = summaryRevenue;
        }
    }
}
