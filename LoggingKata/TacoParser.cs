using System;

namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the TacoBells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            logger.LogInfo("Begin parsing");
            
            if (string.IsNullOrEmpty(line))
            {
                logger.LogError("This line is empty");
                return null;
            }

            var cells = line.Split(',');
            if (cells.Length < 3)
            {
                logger.LogError("This line is an invalid length");
                return null;
            }

            var lon = Double.Parse(cells[0]);
            var lat = Double.Parse(cells[1]);
            var name = cells[2];
            try
            {
                if (lat > Point.MaxLat || lat < -Point.MaxLat)
                {
                    logger.LogError("This Latitude is out of range");
                    return null;
                }
                if (lon > Point.MaxLon || lon < -Point.MaxLon)
                {
                    logger.LogError("This Longitude is out of range");
                    return null;
                }
            }
            catch (Exception e)
            {
                logger.LogError("Something did not parse correctly");
                Console.WriteLine(e);
                return null;
            }

            return new TacoBell
            {
                Location = new Point {Longitude = lon, Latitude = lat},
                Name = name
            };
        }
    }
}