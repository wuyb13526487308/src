using System;
using System.Collections.Generic;

namespace DevExpress.Web.Demos {
    public static class WeatherInLondon {
        public static IList<DayWeather> GetWeatherHistory() {
            IList<DayWeather> weatherHistory = new List<DayWeather>();
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 11, 6, 0, 0), 56.48, 1023, 69));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 11, 3, 0, 0), 53.78, 1021, 76));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 11, 0, 0, 0), 57.74, 1023, 66));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 10, 21, 0, 0), 64.4, 1021, 49));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 10, 18, 0, 0), 72.5, 1020, 45));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 10, 15, 0, 0), 72.68, 1021, 48));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 10, 12, 0, 0), 69.62, 1023, 57));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 10, 9, 0, 0), 67.28, 1023, 66));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 10, 6, 0, 0), 62.42, 1023, 78));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 10, 3, 0, 0), 60.62, 1021, 83));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 10, 0, 0, 0), 62.6, 1023, 72));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 9, 21, 0, 0), 71.96, 1023, 52));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 9, 18, 0, 0), 77.9, 1021, 40));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 9, 15, 0, 0), 78.98, 1023, 41));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 9, 12, 0, 0), 76.28, 1024, 37));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 9, 9, 0, 0), 71.06, 1024, 41));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 9, 6, 0, 0), 60.8, 1024, 68));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 9, 3, 0, 0), 58.64, 1023, 78));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 9, 0, 0, 0), 63.14, 1024, 71));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 8, 21, 0, 0), 68.54, 1023, 63));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 8, 18, 0, 0), 75.2, 1021, 47));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 8, 15, 0, 0), 77.18, 1021, 44));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 8, 12, 0, 0), 74.48, 1021, 48));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 8, 9, 0, 0), 64.58, 1021, 68));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 8, 6, 0, 0), 59.36, 1020, 81));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 8, 3, 0, 0), 60.08, 1019, 85));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 8, 0, 0, 0), 61.16, 1019, 76));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 7, 21, 0, 0), 63.86, 1019, 65));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 7, 18, 0, 0), 65.66, 1017, 57));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 7, 15, 0, 0), 65.12, 1017, 62));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 7, 12, 0, 0), 63.86, 1017, 53));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 7, 9, 0, 0), 61.52, 1017, 62));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 7, 6, 0, 0), 51.8, 1017, 76));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 7, 3, 0, 0), 52.34, 1016, 80));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 7, 0, 0, 0), 57.2, 1016, 82));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 6, 21, 0, 0), 60.44, 1016, 73));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 6, 18, 0, 0), 65.48, 1015, 57));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 6, 15, 0, 0), 66.56, 1015, 55));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 6, 12, 0, 0), 64.04, 1015, 64));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 6, 9, 0, 0), 60.26, 1015, 74));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 6, 6, 0, 0), 51.44, 1015, 89));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 6, 3, 0, 0), 50.18, 1015, 87));
            weatherHistory.Add(new DayWeather(new DateTime(2008, 6, 6, 0, 0, 0), 56.12, 1015, 80));
            return weatherHistory;
        }
        public static IList<DayTemperature> GetTemperatureHistory() {
            List<DayTemperature> temperatureHistory = new List<DayTemperature>();
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 01, 01), 6));
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 02, 01), 7));
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 03, 01), 10));
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 04, 01), 14));
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 05, 01), 18));
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 06, 01), 21));
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 07, 01), 22));
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 08, 01), 22));
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 09, 01), 19));
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 10, 01), 15));
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 11, 01), 10));
            temperatureHistory.Add(new DayTemperature(DayPart.Day, new DateTime(2001, 12, 01), 7));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 01, 01), 2));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 02, 01), 2));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 03, 01), 3));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 04, 01), 5));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 05, 01), 8));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 06, 01), 11));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 07, 01), 13));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 08, 01), 13));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 09, 01), 11));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 10, 01), 8));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 11, 01), 5));
            temperatureHistory.Add(new DayTemperature(DayPart.Night, new DateTime(2001, 12, 01), 3));
            return temperatureHistory;
        }
    }

    public class DayWeather {
        DateTime date;
        double temperature;
        double pressure;
        double relativeHumidity;

        public DateTime Date { get { return date; } }
        public double Temperature { get { return temperature; } }
        public double Pressure { get { return pressure; } }
        public double RelativeHummidity { get { return relativeHumidity; } }

        public DayWeather(DateTime date, double temperature, double pressure, double relativeHumidity) {
            this.date = date;
            this.temperature = temperature;
            this.pressure = pressure;
            this.relativeHumidity = relativeHumidity;
        }
    }

    public enum DayPart {
        Day,
        Night
    }

    public class DayTemperature {
        int temperature;
        DateTime date;
        DayPart dayPart;

        public int Temperature { get { return temperature; } }
        public DateTime Date { get { return date; } }
        public DayPart DayPart { get { return dayPart; } }

        public DayTemperature(DayPart dayPart, DateTime date, int temperature) {
            this.dayPart = dayPart;
            this.date = date;
            this.temperature = temperature;
        }
    }
}
