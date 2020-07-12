using System.Linq;
using GuessNumberGame.Guesses;
using GuessNumberGame.GuessObservers;
using Moq;
using Xunit;

namespace GuessNumberGame.Tests.Guesses
{
    public class CheatingThoroughGuessTests
    {
        private readonly CheatingThoroughGuess _cheatingThoroughGuess;
        private readonly  Mock<IGuessSubject> _guessSubject = new Mock<IGuessSubject>();

        public CheatingThoroughGuessTests()
        {
            _cheatingThoroughGuess = new CheatingThoroughGuess(_guessSubject.Object);
        }

        [Fact]
        public void CheatingThoroughGuess_ShouldRegisterObserver_WhenConstructorCalled()
        {
            // Arrange
            // Act
            // Assert
            _guessSubject.Verify(_ => _.RegisterObserver(_cheatingThoroughGuess), Times.Once);
        }

        [Fact]
        public void MakeGuess_ShouldReturnNextNumberFromMinimum()
        {
            // Arrange
            // Act
            var result = _cheatingThoroughGuess.MakeGuess(GameSettings.MinWeight, GameSettings.MaxWeight);

            // Assert
            Assert.Equal(GameSettings.MinWeight + 1, result);
        }

        [Fact]
        public void MakeGuess_ShouldSkipNumber_WhenItWasAlreadyGuessed()
        {
            // Arrange
            int[] guessedNumbers = new[]
            {
                GameSettings.MinWeight + 1,
                GameSettings.MinWeight + 2,
                GameSettings.MinWeight + 3,
            };

            foreach (var number in guessedNumbers)
            {
                _cheatingThoroughGuess.NumberGuessed(number);
            }

            // Act
            var result = _cheatingThoroughGuess.MakeGuess(GameSettings.MinWeight, GameSettings.MaxWeight);

            // Assert
            Assert.Equal(guessedNumbers.Last() + 1, result);
        }
    }
}
