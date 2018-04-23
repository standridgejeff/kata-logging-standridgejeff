using System;

namespace LoggingKata
{
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Parsing");
            
            if (string.IsNullOrEmpty(line))
            {
                logger.LogFatal("This line is empty");
                return null;
            }

            var cells = line.Split(',');
            if (cells.Length < 2)
            {
                logger.LogWarning("This line is an invalid length");
                return null;
            }

            try
            {
                var lon = Double.Parse(cells[0]);
                if (Math.Abs(lon) > Point.MaxLon)
                {
                    logger.LogError("This Latitude is out of range");
                    return null;
                }

                var lat = Double.Parse(cells[1]);
                if (Math.Abs(lat) > Point.MaxLat)
                {
                    logger.LogError("This Longitude is out of range");
                    return null;
                }

                var name = cells[2];
                return new TacoBell
                {
                Location = new Point {Longitude = lon, Latitude = lat},
                Name = name
                };
            }
            catch (Exception e)
            {
                logger.LogError("Something did not parse correctly");
                Console.WriteLine(e);
                return null;
            }
            
        }
    }
}