using System;

namespace OpenWeatherMap
{
    public class Weather
    {
        public DateTime Date { get; }
        public Location Location { get; }
        public string CurrentState { get; }
        public Wind Wind { get; }
        public string Humidity { get; }
        public Temperature Temperature { get; }
        public string Cloudiness { get; }
        public DateTime Sunset { get; }
        public DateTime Sunrise { get; }
        public string Pressure { get; }
        public string Visibility { get; }

        public Weather(string city, string country, double unixDate, string longitude, string latitude, string currentState,
            string currentTemperature, string windSpeed, double windDegrees, string humidity, string minTemperature,
            string maxTemperature, string cloudiness, double sunset, double sunrise, string visibility, string pressure)
        {
            Date = UnixTimeStampToDateTime(unixDate);
            Location = new Location(city, country, longitude, latitude);
            CurrentState = currentState;
            Wind = new Wind(windSpeed, windDegrees);
            Humidity = humidity;
            Temperature = new Temperature(minTemperature, maxTemperature, currentTemperature);
            Cloudiness = cloudiness;
            Visibility = visibility;
            Pressure = pressure;
            Sunset = UnixTimeStampToDateTime(sunset);
            Sunrise = UnixTimeStampToDateTime(sunrise);
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
