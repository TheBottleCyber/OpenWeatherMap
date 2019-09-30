using System;

namespace OpenWeatherMap
{
    public class Wind
    {
        public string Speed { get; }
        public string Cardinal { get; }
        public double Degress { get; }

        public Wind(string speed, double degress)
        {
            Speed = speed;
            Degress = degress;
            Cardinal = DegreesToCardinal(degress);
        }

        public static string DegreesToCardinal(double degrees)
        {
            string[] caridnals = { "North", "North-East", "East", "South-East", "South", "South-West", "West", "North-West", "North" };
            //string[] caridnals = { "Северный", "Северо-Восточный", "Восточный", "Южно-Восточный", "Южный", "Южно-Западный", "Западный", "Северно-Западный", "Северный" };
            return caridnals[(int)Math.Round(degrees % 360 / 45)];
        }
    }
}
