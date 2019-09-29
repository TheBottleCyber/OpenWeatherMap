using System;
using OpenWeatherMap;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new OpenWeatherMapClient("d9ef62e1a9cdca288189217e245bf78d");
            
            string tempSymbol = "\u00B0C"; // °C
            string windSymbol = "m/s";
            Console.Write("Available measurement systems : \n\n1 - Default\n2 - Metric\n3 - Imperial\n\nEnter the number corresponding to the measurement system or leave blank to select Metric : ");
            string inputUnitsType = Console.ReadLine();

            UnitsType unitsType = UnitsType.Metric;
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
            string cityRequest = Console.ReadLine();
            Console.Clear();

            Weather currentWeather = string.IsNullOrEmpty(cityRequest) || string.IsNullOrWhiteSpace(cityRequest)
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
        }
    }
}
