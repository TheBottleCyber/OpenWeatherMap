using System;

namespace OpenWeatherMap
{
    public class Wind
    {
        public string Speed { get; }
        public string Cardinal { get; }
        public double Degress { get; }

        public Wind(string speed, double degress, Language language)
        {
            Speed = speed;
            Degress = degress;
            Cardinal = DegreesToCardinal(degress, language);
        }

        private static string DegreesToCardinal(double degrees, Language language)
        {
            string[] caridnals = { "North", "North-East", "East", "South-East", "South", "South-West", "West", "North-West", "North" };
            if (language == Language.Russian)
            {
                caridnals = new []
                {
                    "Северный", "Северо-Восточный", "Восточный", "Южно-Восточный", "Южный", "Южно-Западный", "Западный", "Северно-Западный",
                    "Северный"
                };
            }

            return caridnals[(int)Math.Round(degrees % 360 / 45)];
        }
    }
}
