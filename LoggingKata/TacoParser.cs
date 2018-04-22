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
                logger.LogError("MT line");
                return null;
            }

            var cells = line.Split(',');
            if (cells.Length < 2)
            {
                logger.LogError("No lat or long");
                return null;
            }


            //DO not fail if one record parsing fails, return null
            //TODO Implement
        }
    }
}