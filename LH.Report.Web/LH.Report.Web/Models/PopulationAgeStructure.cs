using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class PopulationAgeProvider {
        public static IList<AgePopulation> GetPopulationAgeStructure() {
            string[] countries = new string[] { "United States", "Brazil", "Russia", "Japan", "Mexico", "Germany", "United Kingdom" };
            string[] ageCategories = new string[] { "Male: 0-14 years", "Male: 15-64 years", "Male: 65 years and older",
                "Female: 0-14 years", "Female: 15-64 years", "Female: 65 years and older" };
            Dictionary<string, double[]> population = new Dictionary<string, double[]>();
            population.Add(ageCategories[0], new double[] { 29.956, 25.607, 13.493, 9.575, 17.306, 6.679, 5.816 });
            population.Add(ageCategories[1], new double[] { 90.354, 55.793, 48.983, 43.363, 30.223, 28.638, 19.622 });
            population.Add(ageCategories[2], new double[] { 14.472, 3.727, 5.802, 9.024, 1.927, 5.133, 3.864 });
            population.Add(ageCategories[3], new double[] { 28.597, 24.67, 12.971, 9.105, 16.632, 6.333, 5.519 });
            population.Add(ageCategories[4], new double[] { 91.827, 57.598, 52.14, 42.98, 31.868, 27.693, 19.228 });
            population.Add(ageCategories[5], new double[] { 20.362, 5.462, 12.61, 12.501, 2.391, 8.318, 5.459 });

            List<AgePopulation> result = new List<AgePopulation>();
            foreach (string ageCatregory in ageCategories)
                for (int i = 0; i < countries.Length; i++)
                    result.Add(new AgePopulation(countries[i], ageCatregory, population[ageCatregory][i]));
            return result;
        }
    }

    public class AgePopulation {
        string name;
        string age;
        double population;

        public string Name { get { return name; } }
        public string Age { get { return age; } }
        public double Population { get { return population; } }

        public AgePopulation(string name, string age, double population) {
            this.name = name;
            this.age = age;
            this.population = population;
        }
    }
}
