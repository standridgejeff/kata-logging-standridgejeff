using System;
using Xunit;
using Xunit.Sdk;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {

        [Theory]
        [InlineData("-86.889051, 33.556383, Taco Bell Birmingham")]
        public void ShouldParse(string line)
        {
            //Arrange is for creating variables/instances
            var tParser = new TacoParser();
   
            // Act is doing something with those variables
            var result = tParser.Parse(line);

            // Assert is comparing expected data with what's actually passed in by your program
            Assert.NotNull(result.Name);
            Assert.NotNull(result.Location);
            // TODO: Complete Should Parse
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("1234, 1234")] // Cannot parse arrays of length < 3.
        [InlineData("1234, 1234, Location, Other")] // Cannot parse arrays of Length > 3.
        [InlineData("-190.05, 85.50, Location")] // Longitude out of range.
        [InlineData("170.02, 100.20, Location")] // Latitude out of range.
        public void ShouldFailParse(string line)
        {
            // Arrange is for creating new variables/instances
            var tParser = new TacoParser();
            ITrackable expected = null;
            // Act is doing something with those variables
            var actual = tParser.Parse(line);

            // Assert is comparing expected data with what's actually passed in by your program
            Assert.Equal(expected, actual);
            // TODO: Complete Should Fail Parse
        }
    }
}

