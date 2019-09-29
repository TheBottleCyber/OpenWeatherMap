using System;

namespace OpenWeatherMap
{
    public class Weather
    {
        public DateTime Date { get; private set; }
        public Location Location { get; private set; }
        public string CurrentState { get; private set; }
        public Wind Wind { get; private set; }
        public string Humidity { get; private set; }
        public Temperature Temperature { get; private set; }
        public string Cloudiness { get; private set; }
        public DateTime Sunset { get; private set; }
        public DateTime Sunrise { get; private set; }

        public Weather(string city, string country, double unixDate, string longitude, string latitude, string currentState,
            string currentTemperature, string windSpeed, double windDegrees, string humidity, string minTemperature,
            string maxTemperature, string cloudiness, double sunset, double sunrise)
        {
            Date = UnixTimeStampToDateTime(unixDate);
            Location = new Location(city, country, longitude, latitude);
            CurrentState = currentState;
            Wind = new Wind(windSpeed, windDegrees);
            Humidity = humidity;
            Temperature = new Temperature(minTemperature, maxTemperature, currentTemperature);
            Cloudiness = cloudiness;
            Sunset = UnixTimeStampToDateTime(sunset);
            Sunrise = UnixTimeStampToDateTime(sunrise);
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
