using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class CountriesProvider {
        public static IList<Country> GetCountries() {
            return new List<Country>(){
                new Country("Russia", 17.0752),
                new Country("Canada", 9.98467),
                new Country("USA", 9.63142),
                new Country("China", 9.59696),
                new Country("Brazil", 8.511965),
                new Country("Australia", 7.68685),
                new Country("India", 3.28759),
                new Country("Others", 81.2)
            };
        }
    }

    public class Country {
        string name;
        double area;

        public string Name { get { return name; } }
        public double Area { get { return area; } }

        public Country(string name, double area) {
            this.name = name;
            this.area = area;
        }
    }
}
