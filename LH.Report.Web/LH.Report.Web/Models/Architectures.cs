using System;
using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class ArchitectureProvider {
        public static List<Architecture> GetArchitecturesValues() {
            string[] architectures = new string[] { "SMP", "MPP", "Constellations", "Cluster" };
            DateTime[] dates = new DateTime[] { new DateTime(1997, 11, 01), new DateTime(1999, 11, 01),
                new DateTime(2001, 11, 01), new DateTime(2003, 11, 01), new DateTime(2005, 11, 01), new DateTime(2007, 11, 01)};
            Dictionary<string, double[]> values = new Dictionary<string, double[]>();
            values.Add(architectures[0], new double[] { 10, 962, 18832, 264332, 1112753, 4169758 });
            values.Add(architectures[1], new double[] { 391, 4082, 21932, 64195, 78473, 101830 });
            values.Add(architectures[2], new double[] { 11994, 38377, 88395, 200715, 1107271, 2694582 });
            values.Add(architectures[3], new double[] { 4502, 7518, 5818, 0, double.NaN, double.NaN });

            List<Architecture> result = new List<Architecture>();
            foreach (string architecture in architectures)
                for (int i = 0; i < dates.Length; i++)
                    result.Add(new Architecture(architecture, dates[i], values[architecture][i]));
            return result;
        }
    }

    public class Architecture {
        string name;
        DateTime date;
        double gigaflops;

        public string Name { get { return name; } }
        public DateTime Date { get { return date; } }
        public double Gigaflops { get { return gigaflops; } }

        public Architecture(string name, DateTime date, double gigaflops) {
            this.name = name;
            this.date = date;
            this.gigaflops = gigaflops;
        }
    }
}
