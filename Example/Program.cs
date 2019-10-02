using System;
using OpenWeatherMap;

namespace Example
{
    internal static class Program
    {
        private static void Main()
        {
            var client = new OpenWeatherMapClient("d9ef62e1a9cdca288189217e245bf78d");

            var tempSymbol = "\u00B0C"; // °C
            var windSymbol = "m/s";
            Console.Write("Available measurement systems : \n\n" +
                          "1 - Default\n" +
                          "2 - Metric\n" +
                          "3 - Imperial\n\n" +
                          "Enter the number corresponding to the measurement system or leave blank to select Metric : ");

            var inputUnitsType = Console.ReadLine();

            UnitsType unitsType;
            switch (inputUnitsType)
            {
                case "1":
                    tempSymbol = "K"; // Kelvins
                    unitsType = UnitsType.Default;
                    break;
                case "2":
                    unitsType = UnitsType.Metric;
                    break;
                case "3":
                    unitsType = UnitsType.Imperial;
                    tempSymbol = "\u00B0F"; // °F
                    windSymbol = "mph";
                    break;
                default:
                    unitsType = UnitsType.Metric;
                    break;
            }

            Console.Clear();
            Console.Write("Enter a city or leave blank for autolocation : ");
            var cityRequest = Console.ReadLine();
            Console.Clear();

            var currentWeather = string.IsNullOrEmpty(cityRequest) || string.IsNullOrWhiteSpace(cityRequest)
                ? client.GetByIPGeoLocation(unitsType)
                : client.GetByCityName(cityRequest, unitsType);

            Console.WriteLine($"Country : {currentWeather.Location.Country}");
            Console.WriteLine($"City : {currentWeather.Location.City}");
            Console.WriteLine($"Data calculation time : {currentWeather.Date}");
            Console.WriteLine($"Coordinates of the city : {currentWeather.Location.Longitude}, {currentWeather.Location.Latitude}");
            Console.WriteLine($"Current state : {currentWeather.CurrentState}");
            Console.WriteLine($"Air temperature : {currentWeather.Temperature.Current}{tempSymbol} Min : {currentWeather.Temperature.Minimum}{tempSymbol} Max : {currentWeather.Temperature.Maximum}{tempSymbol}");
            Console.WriteLine($"Wind direction : {currentWeather.Wind.Cardinal}");
            Console.WriteLine($"Wind speed : {currentWeather.Wind.Speed} {windSymbol}");
            Console.WriteLine($"Humidity: {currentWeather.Humidity}%");
            Console.WriteLine($"Cloudiness : {currentWeather.Cloudiness}%");
            Console.WriteLine($"Sunrise time : {currentWeather.Sunrise}");
            Console.WriteLine($"Sunset time : {currentWeather.Sunset}");
            Console.WriteLine($"Visibility : {currentWeather.Pressure}");
            Console.WriteLine($"Pressure : {currentWeather.Visibility}");

            Console.WriteLine($"\nRequest Status Code : {client.ResponseCode}");
            Console.ReadLine();
        }
    }
}