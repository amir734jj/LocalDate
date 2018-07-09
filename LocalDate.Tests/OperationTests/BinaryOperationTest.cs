using Xunit;
using AutoFixture;

namespace LocalDate.Tests.OperationTests
{
    public class BinaryOperationTest: LocalDateFixture
    {
        [Fact]
        public void Test__AddLocalDates()
        {
            // Arrange
            var localDate1 = new LocalDate(1000, 10, 10);
            var localDate2 = new LocalDate(500, 10, 10);
            var expected = new LocalDate(1501, 8, 20);
            
            // Act
            var result = localDate1 + localDate2;

            // Assert
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void Test__SubtractLocalDates()
        {
            // Arrange
            var localDate1 = new LocalDate(1501, 8, 20);
            var localDate2 = new LocalDate(1000, 10, 10);
            var expected = new LocalDate(500, 10, 10);

            // Act
            var result = localDate1 - localDate2;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}