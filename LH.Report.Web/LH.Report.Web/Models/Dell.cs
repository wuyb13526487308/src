using System;
using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class DellStockPricesProvider {
        public static IList<StockPrice> GetDellStockPrices() {
            List<StockPrice> dell = new List<StockPrice>();
            dell.Add(new StockPrice(new DateTime(1994, 3, 1), 24.00, 25.00, 25.00, 24.875));
            dell.Add(new StockPrice(new DateTime(1994, 3, 2), 23.625, 25.125, 24.00, 24.875));
            dell.Add(new StockPrice(new DateTime(1994, 3, 3), 26.25, 28.25, 26.75, 27.00));
            dell.Add(new StockPrice(new DateTime(1994, 3, 4), 26.50, 27.875, 26.875, 27.25));
            dell.Add(new StockPrice(new DateTime(1994, 3, 7), 26.375, 27.50, 27.375, 26.75));
            dell.Add(new StockPrice(new DateTime(1994, 3, 8), 25.75, 26.875, 26.75, 26.00));
            dell.Add(new StockPrice(new DateTime(1994, 3, 9), 25.75, 26.75, 26.125, 26.25));
            dell.Add(new StockPrice(new DateTime(1994, 3, 10), 25.75, 26.375, 26.375, 25.875));
            dell.Add(new StockPrice(new DateTime(1994, 3, 11), 24.875, 26.125, 26.00, 25.375));
            dell.Add(new StockPrice(new DateTime(1994, 3, 14), 25.125, 26.00, 25.625, 25.75));
            dell.Add(new StockPrice(new DateTime(1994, 3, 15), 25.875, 26.625, 26.125, 26.375));
            dell.Add(new StockPrice(new DateTime(1994, 3, 16), 26.25, 27.375, 26.25, 27.25));
            dell.Add(new StockPrice(new DateTime(1994, 3, 17), 26.875, 27.25, 27.125, 26.875));
            dell.Add(new StockPrice(new DateTime(1994, 3, 18), 26.375, 27.125, 27.00, 27.125));
            dell.Add(new StockPrice(new DateTime(1994, 3, 21), 26.75, 27.875, 26.875, 27.75));
            dell.Add(new StockPrice(new DateTime(1994, 3, 22), 26.75, 28.375, 27.50, 27.00));
            dell.Add(new StockPrice(new DateTime(1994, 3, 23), 26.875, 28.125, 27.00, 28.00));
            dell.Add(new StockPrice(new DateTime(1994, 3, 24), 26.25, 27.875, 27.75, 27.625));
            dell.Add(new StockPrice(new DateTime(1994, 3, 25), 27.50, 28.75, 27.75, 28.00));
            dell.Add(new StockPrice(new DateTime(1994, 3, 28), 25.75, 28.25, 28.00, 27.25));
            dell.Add(new StockPrice(new DateTime(1994, 3, 29), 26.375, 27.50, 27.50, 26.875));
            dell.Add(new StockPrice(new DateTime(1994, 3, 30), 25.75, 27.50, 26.375, 26.25));
            dell.Add(new StockPrice(new DateTime(1994, 3, 31), 24.75, 27.00, 26.50, 25.25));
            return dell;
        }
    }

    public class StockPrice {
        DateTime date;
        double lowValue;
        double highValue;
        double openValue;
        double closeValue;

        public DateTime Date { get { return date; } }
        public double LowValue { get { return lowValue; } }
        public double HighValue { get { return highValue; } }
        public double OpenValue { get { return openValue; } }
        public double CloseValue { get { return closeValue; } }

        public StockPrice(DateTime date, double lowValue, double highValue, double openValue, double closeValue) {
            this.date = date;
            this.lowValue = lowValue;
            this.highValue = highValue;
            this.openValue = openValue;
            this.closeValue = closeValue;
        }
    }
}
