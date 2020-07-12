using GuessNumberGame.Utils;
using Xunit;

namespace GuessNumberGame.Tests.Utils
{
    public class RoundCalculatorTests
    {
        private readonly RoundCalculator _calculator;

        public RoundCalculatorTests()
        {
            _calculator = new RoundCalculator();
        }

        [Theory]
        [InlineData(100, 70, 2)]
        [InlineData(100, 130, 2)]
        public void GetNumberOfRoundsToSkip_ShouldReturnValidNumberOfRoundsToSkip(int weight, int guess, int skipRounds)
        {
            // Arrange
            // Act
            var result = _calculator.GetNumberOfRoundsToSkip(weight, guess);

            // Assert
            Assert.Equal(skipRounds, result);
        }

        [Theory]
        [InlineData(100, 95)]
        [InlineData(100, 103)]
        public void GetNumberOfRoundsToSkip_ShouldReturnZero_WhenThereIsNoRoundsToSkip(int weight, int guess)
        {
            // Arrange
            // Act
            var result = _calculator.GetNumberOfRoundsToSkip(weight, guess);

            // Assert
            Assert.Equal(0, result);
        }
    }
}
