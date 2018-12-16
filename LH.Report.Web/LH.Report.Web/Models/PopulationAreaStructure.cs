using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class PopulationAreaProvider {
        public static IList<AreaPopulation> GetPopulationAreaStructure() {
            return new List<AreaPopulation>(){
                new AreaPopulation(1, "Argentina", 2777815, 32300003),
                new AreaPopulation(2, "Bolivia", 1098575, 7300000),
                new AreaPopulation(3, "Brazil", 8511196, 150400000),
                new AreaPopulation(4, "Canada", 9976147, 26500000),
                new AreaPopulation(5, "Chile", 756943, 13200000),
                new AreaPopulation(6, "Colombia", 1138907, 33000000),
                new AreaPopulation(7, "Cuba", 114524, 10600000),
                new AreaPopulation(8, "Ecuador", 455502, 10600000),
                new AreaPopulation(9, "El Salvador", 20865, 5300000),
                new AreaPopulation(10, "Guyana", 214969, 800000),
                new AreaPopulation(11, "Jamaica", 11424, 2500000),
				new AreaPopulation(12, "Mexico", 1967180, 88600000),
				new AreaPopulation(13, "Nicaragua", 139000, 3900000),
                new AreaPopulation(14, "Paraguay", 406576, 4660000),
                new AreaPopulation(15, "Peru", 1285215, 21600000),
                new AreaPopulation(16, "USA", 9363130, 249200000),
                new AreaPopulation(17, "Uruguay", 176140, 3002000),
                new AreaPopulation(18, "Venezuela", 912047, 19700000)
            };
        }
    }

    public class AreaPopulation {
        int id;
        string name;
        int area;
        int population;

        public int ID { get { return id; } }
        public string Name { get { return name; } }
        public int Area { get { return area; } }
        public int Population { get { return population; } }

        public AreaPopulation(int id, string name, int area, int population) {
            this.id = id;
            this.name = name;
            this.area = area;
            this.population = population;
        }
    }
}
