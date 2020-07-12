using GuessNumberGame.Guesses;
using Xunit;

namespace GuessNumberGame.Tests.Guesses
{
    public class RandomGuessTests
    {
        private readonly RandomGuess _randomGuess;

        public RandomGuessTests()
        {
            _randomGuess = new RandomGuess();
        }

        [Fact]
        public void MakeGuess_ShouldGenerateNumber()
        {
            // Arrange
            int min = 0;
            int max = 10;

            // Act
            int result = _randomGuess.MakeGuess(min, max);

            // Assert
            Assert.InRange(result, min, max);
        }
    }
}
