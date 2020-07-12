using System.Collections.Generic;
using GuessNumberGame.Guesses;
using GuessNumberGame.GuessObservers;
using GuessNumberGame.Utils;
using Moq;
using Xunit;

namespace GuessNumberGame.Tests.Guesses
{
    public class CheatingRandomGuessTests
    {
        private readonly CheatingRandomGuess _cheatingRandomGuess;
        private readonly Mock<IRandomGenerator> _randomGenerator  = new Mock<IRandomGenerator>();
        private readonly  Mock<IGuessSubject> _guessSubject = new Mock<IGuessSubject>();

        public CheatingRandomGuessTests()
        {
            _cheatingRandomGuess = new CheatingRandomGuess(_randomGenerator.Object, _guessSubject.Object);
        }

        [Fact]
        public void CheatingRandomGuess_ShouldRegisterObserver_WhenConstructorCalled()
        {
            // Arrange
            // Act
            // Assert
            _guessSubject.Verify(_ => _.RegisterObserver(_cheatingRandomGuess), Times.Once);
        }

        [Fact]
        public void MakeGuess_ShouldReturnNumber()
        {
            // Arrange
            int min = 0;
            int max = 10;
            int expected = 4;

            _randomGenerator.Setup(
                    _ => _.Generate(min, max, It.IsAny<SortedSet<int>>()))
                .Returns(expected);

            // Act
            var result = _cheatingRandomGuess.MakeGuess(min, max);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MakeGuess_ShouldIgnoreNumbers_WhenTheyWereAlreadyGuessed()
        {
            // Arrange
            int min = 0;
            int max = 10;
            int expected = 7;
            int[] guessedNumbers = new[] {3, 4, 5};

            foreach (var number in guessedNumbers)
            {
                _cheatingRandomGuess.NumberGuessed(number);
            }

            _randomGenerator.Setup(
                    _ => _.Generate(min, max, It.IsAny<SortedSet<int>>()))
                .Returns(expected);

            // Act
            var result = _cheatingRandomGuess.MakeGuess(min, max);

            // Assert
            _randomGenerator
                .Verify(
                    _ => _.Generate(
                        min,
                        max,
                        It.Is<SortedSet<int>>(set => set.Count == guessedNumbers.Length)));
        }

        [Fact]
        public void MakeGuess_ShouldNotRememberSameNumberTwice_WhenItWasAlreadyGuessed()
        {
            // Arrange
            int min = 0;
            int max = 10;
            int expected = 7;
            int[] guessedNumbers = new[] {3, 3};

            foreach (var number in guessedNumbers)
            {
                _cheatingRandomGuess.NumberGuessed(number);
            }

            _randomGenerator.Setup(
                    _ => _.Generate(min, max, It.IsAny<SortedSet<int>>()))
                .Returns(expected);

            // Act
            var result = _cheatingRandomGuess.MakeGuess(min, max);

            // Assert
            _randomGenerator
                .Verify(
                    _ => _.Generate(
                        min,
                        max,
                        It.Is<SortedSet<int>>(set => set.Count == guessedNumbers.Length - 1)));
        }
    }
}
