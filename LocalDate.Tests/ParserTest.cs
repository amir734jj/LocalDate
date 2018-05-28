using LocalDate.Factories;
using Xunit;

namespace LocalDate.Tests
{
    public class ParserTest
    {
        [Fact]
        public void Test__BasicPattern()
        {
            // Arrange
            const string str = "01/02/2010";
            var expected = new LocalDate(2010, 1, 2);

            // Act
            var result = LocalDateFactory.ParseLocalDate(str);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Test__NamedMonths()
        {
            // Arrange
            const string str = "January 2, 2010";
            var expected = new LocalDate(2010, 1, 2);

            // Act
            var result = LocalDateFactory.ParseLocalDate(str);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}