using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class GreatLakesStateProductProvider {
        public static IList<GreatLakesStateProduct> GetGreatLakesStateProduct() {
            string[] states = new string[] { "Illinois", "Indiana", "Michigan", "Ohio", "Wisconsin" };
            string[] years = new string[] { "1998", "2001", "2004" };
            Dictionary<string, IList<double>> values = new Dictionary<string, IList<double>>();
            values.Add(years[0], new double[] { 423.721, 178.719, 308.845, 348.555, 160.274 });
            values.Add(years[1], new double[] { 476.851, 195.769, 335.793, 374.771, 182.373 });
            values.Add(years[2], new double[] { 528.904, 227.271, 372.576, 418.258, 211.727 });

            List<GreatLakesStateProduct> result = new List<GreatLakesStateProduct>();
            foreach (string year in years)
                for (int i = 0; i < states.Length; i++)
                    result.Add(new GreatLakesStateProduct(states[i], year, values[year][i]));
            return result;
        }
    }

    public class GreatLakesStateProduct {
        string state;
        string year;
        double product;

        public string State { get { return state; } }
        public string Year { get { return year; } }
        public double Product { get { return product; } }

        public GreatLakesStateProduct(string state, string year, double product) {
            this.state = state;
            this.year = year;
            this.product = product;
        }
    }
}
