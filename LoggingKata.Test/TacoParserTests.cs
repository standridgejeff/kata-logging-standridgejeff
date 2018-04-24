using Xunit;


namespace LoggingKata.Test
{
    public class TacoParserTests
    {

        [Theory]
        [InlineData("-86.889051, 33.556383, Taco Bell Birmingham")]
        [InlineData("-86.889051, 33.56383")]
        public void ShouldParse(string line)
        {
            var tParser = new TacoParser();

            var result = tParser.Parse(line);

            Assert.NotNull(result);
            Assert.NotNull(result.Location);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1234, 1234")]
        [InlineData("1234, 1234, Location, Other")]
        [InlineData("-190.05, 85.50, Location")]
        [InlineData("170.02, 100.20, Location")]
        public void ShouldFailParse(string line)
        {
            var tParser = new TacoParser();
            ITrackable expected = null;

            var actual = tParser.Parse(line);

            Assert.Equal(expected, actual);
        }
    }
}

