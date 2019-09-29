namespace OpenWeatherMap
{
    public class Location
    {
        public string City { get; private set; }
        public string Country { get; private set; }
        public string Longitude { get; private set; }
        public string Latitude { get; private set; }

        public Location(string city, string country, string longitude, string latitude)
        {
            City = city;
            Country = country;
            Longitude = longitude;
            Latitude = latitude;
        }
    }
}
