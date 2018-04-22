using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldDoSomething()
        {
            // TODO: Complete Something, if anything
        }

        [Theory]
        [InlineData("Example")]
        public void ShouldParse(string line)
        {
            var 
            // TODO: Complete Should Parse
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("45")]
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

