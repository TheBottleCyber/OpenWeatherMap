namespace OpenWeatherMap
{
    public class Temperature
    {
        public string Minimum { get; }
        public string Maximum { get; }
        public string Current { get; }

        public Temperature(string minimum, string maximum, string current)
        {
            Minimum = minimum;
            Maximum = maximum;
            Current = current;
        }
    }
}
