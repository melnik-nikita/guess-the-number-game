using GuessNumberGame.Guesses;
using Xunit;

namespace GuessNumberGame.Tests.Guesses
{
    public class ThroughGuessTests
    {
        private readonly ThroughGuess _throughGuess;

        public ThroughGuessTests()
        {
            _throughGuess = new ThroughGuess();
        }

        [Fact]
        public void MakeGuess_ShouldReturnNextNumberFromMinimum()
        {
            // Arrange
            // Act
            var result = _throughGuess.MakeGuess(GameSettings.MinWeight, GameSettings.MaxWeight);

            // Assert
            Assert.Equal(GameSettings.MinWeight + 1, result);
        }

        [Fact]
        public void MakeGuess_ShouldIncreaseGuessByOne()
        {
            // Arrange
            int rounds = 5;

            // Act
            int result = default;

            for (int i = 0; i < rounds; i++)
            {
                result = _throughGuess.MakeGuess(GameSettings.MinWeight, GameSettings.MaxWeight);
            }

            // Assert
            Assert.Equal(GameSettings.MinWeight + rounds, result);
        }
    }
}
