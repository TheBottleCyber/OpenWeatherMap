namespace OpenWeatherMap
{
    public class Location
    {
        public string City { get; }
        public string Country { get; }
        public string Longitude { get; }
        public string Latitude { get; }

        public Location(string city, string country, string longitude, string latitude)
        {
            City = city;
            Country = country;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
