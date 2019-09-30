using System;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace OpenWeatherMap
{
    public class OpenWeatherMapClient
    {
        private readonly string OpenWeatherMapApi = "http://api.openweathermap.org/data/2.5/weather";

        public OpenWeatherMapClient(string appId)
        {
            if (string.IsNullOrEmpty(appId) || string.IsNullOrWhiteSpace(appId))
                throw new ArgumentException("Parameter cannot be null", nameof(appId));

            AppId = appId;
        }

        public string AppId { get; }
        public HttpStatusCode ResponseCode { get; private set; }

        public Weather GetByCityName(string city, UnitsType unitsType = UnitsType.Metric)
        {
            if (string.IsNullOrEmpty(city) || string.IsNullOrWhiteSpace(city))
                throw new ArgumentException("Parameter cannot be null", nameof(city));

            dynamic jsonCurrentWeather =
                JsonConvert.DeserializeObject(
                    GetRequest(OpenWeatherMapApi + $"?appid={AppId}&q={city}&units={unitsType}"));

            double unixDateTime = jsonCurrentWeather.dt;
            string country = jsonCurrentWeather.sys.country;
            string longitude = jsonCurrentWeather.coord.lon;
            string latitude = jsonCurrentWeather.coord.lat;
            string currentState = Encoding.UTF8.GetString(Encoding.Default.GetBytes((string) jsonCurrentWeather.weather[0].description));
            string currentTemperature = jsonCurrentWeather.main.temp;
            string windSpeed = jsonCurrentWeather.wind.speed;
            double windDegrees = jsonCurrentWeather.wind.deg;
            string humidity = jsonCurrentWeather.main.humidity;
            string minTemperature = jsonCurrentWeather.main.temp_min;
            string maxTemperature = jsonCurrentWeather.main.temp_max;
            string cloudiness = jsonCurrentWeather.clouds.all;
            double unixSunriseDate = jsonCurrentWeather.sys.sunrise;
            double unixSunsetDate = jsonCurrentWeather.sys.sunset;
            string pressure = jsonCurrentWeather.main.pressure;
            string visibility = jsonCurrentWeather.visibility;
            ResponseCode = jsonCurrentWeather.cod;

            return new Weather(city, country, unixDateTime, longitude, latitude, currentState,
                currentTemperature, windSpeed, windDegrees, humidity, minTemperature,
                maxTemperature, cloudiness, unixSunsetDate, unixSunriseDate, pressure, visibility);
        }

        public Weather GetByIPGeoLocation(UnitsType unitsType = UnitsType.Metric)
        {
            dynamic cityIP = JsonConvert.DeserializeObject(GetRequest("http://ip-api.com/json/"));
            return GetByCityName((string) cityIP.city, unitsType);
        }

        private string GetRequest(string url)
        {
            using (var webClient = new WebClient())
            {
                return webClient.DownloadString(url);
            }
        }
    }
}