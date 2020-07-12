using System.Collections.Generic;
using System.Linq;
using GuessNumberGame.Utils;
using Xunit;

namespace GuessNumberGame.Tests.Utils
{
    public class RandomNumberGeneratorTests
    {
        private readonly RandomNumberGenerator _randomNumberGenerator;

        public RandomNumberGeneratorTests()
        {
            _randomNumberGenerator = new RandomNumberGenerator();
        }

        [Fact]
        public void Generate_ShouldReturnNumberBetweenMinAndMax()
        {
            // Arrange
            int min = 0;
            int max = 10;

            // Act
            var result = _randomNumberGenerator.Generate(min, max);

            // Assert
            Assert.InRange(result, min, max);
        }

        [Fact]
        public void Generate_ShouldNotReturnNumbers_WhenExcludedItemsPassed()
        {
            // Arrange
            int min = 0;
            int max = 10;

            List<int> result = new List<int>();

            // Act
            for (int i = min; i < max; i++)
            {
                result.Add(_randomNumberGenerator.Generate(min, max, result));
            }

            // Assert
            Assert.Equal(max, result.ToHashSet().Count);
        }

    }
}
