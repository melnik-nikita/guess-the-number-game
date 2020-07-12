using System.Collections.Generic;
using GuessNumberGame.Guesses;
using GuessNumberGame.Utils;
using Moq;
using Xunit;

namespace GuessNumberGame.Tests.Guesses
{
    public class MemoryGuessTests
    {
        private readonly MemoryGuess _memoryGuess;
        private readonly Mock<IRandomGenerator> _randomGenerator = new Mock<IRandomGenerator>();

        public MemoryGuessTests()
        {
            _memoryGuess = new MemoryGuess(_randomGenerator.Object);
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
            var result = _memoryGuess.MakeGuess(min, max);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void MakeGuess_ShouldRememberGuessedNumber()
        {
            // Arrange
            int min = 0;
            int max = 10;
            int expected = 4;

            _randomGenerator.Setup(
                    _ => _.Generate(min, max, It.IsAny<SortedSet<int>>()))
                .Returns(expected);

            // Act
            _memoryGuess.MakeGuess(min, max);
            _memoryGuess.MakeGuess(min, max);

            // Assert
            _randomGenerator.Verify(
                _ => _.Generate(min, max, It.Is<SortedSet<int>>(set => set.Count == 1)),
                Times.AtLeastOnce);
        }
    }
}
