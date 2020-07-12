using GuessNumberGame.Utils;
using Xunit;

namespace GuessNumberGame.Tests.Utils
{

    public class EnumUtilsTests
    {
        public enum Test
        {
            Test1,
            Test2
        }

        [Theory]
        [InlineData("0", Test.Test1)]
        [InlineData("1", Test.Test2)]
        public void TryGetEnum_ShouldReturnValidEnum_WhenPassedIntStringValue(string input, Test result)
        {
            // Arrange

            // Act
            EnumUtils.TryGetEnum<Test>(input, out Test enumValue);

            // Assert
            Assert.Equal(result, enumValue);
        }

        [Theory]
        [InlineData("Test1", Test.Test1)]
        [InlineData("Test2", Test.Test2)]
        public void TryGetEnum_ShouldReturnValidEnum_WhenPassedEnumStringValue(string input, Test result)
        {
            // Arrange

            // Act
            EnumUtils.TryGetEnum<Test>(input, out Test enumValue);

            // Assert
            Assert.Equal(result, enumValue);
        }
    }
}
