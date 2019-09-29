namespace OpenWeatherMap
{
    public class Temperature
    {
        public string Minimum { get; private set; }
        public string Maximum { get; private set; }
        public string Current { get; private set; }

        public Temperature(string minimum, string maximum, string current)
        {
            Minimum = minimum;
            Maximum = maximum;
            Current = current;
        }
    }
}
