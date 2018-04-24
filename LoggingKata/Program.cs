using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;


namespace LoggingKata
{
    class Program
    {
        static readonly ILog Logger = new TacoLogger();
        
        const string CsvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            Logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(CsvPath);

            Logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();

            var locations = lines.Select(parser.Parse);
            ITrackable a = null;
            ITrackable b = null;
            double distance = 0;

            foreach (var locA in locations)
            {
                var origin = new GeoCoordinate
                {
                    Latitude = locA.Location.Latitude,
                    Longitude = locA.Location.Longitude,
                };

                foreach (var locB in locations)
                {
                    var destination = new GeoCoordinate
                    {
                        Latitude = locB.Location.Latitude,
                        Longitude = locB.Location.Longitude,
                    };

                    var newDistance = origin.GetDistanceTo(destination);
                    if (newDistance > distance)
                    {
                        a = locA;
                        b = locB;
                        distance = newDistance;
                    }
                }
            }

            Console.WriteLine($"The two Taco Bells that are furthest apart are: {a.Name} and {b.Name}");
            Console.WriteLine($"These two locations are {Math.Round(distance/1000)} kilometers apart");
            Console.ReadLine();
        }
    }
}