using Xunit;

namespace LocalDate.Tests.OperationTests
{
    public class ComparisonTest
    {
        [Fact]
        public void Test__GreaterThan()
        {
            // Arrange
            var d1 = new LocalDate(2000, 10, 5);
            var d2 = new LocalDate(2000, 12, 1);

            // Act, Assert
            Assert.True(d2 > d1);
        }
        
        [Fact]
        public void Test__LessThan()
        {
            // Arrange
            var d1 = new LocalDate(2000, 10, 5);
            var d2 = new LocalDate(2000, 12, 1);

            // Act, Assert
            Assert.True(d1 < d2);
        }
        
        [Fact]
        public void Test__Equal()
        {
            // Arrange
            var d1 = new LocalDate(2000, 10, 5);
            var d2 = new LocalDate(2000, 10, 5);

            // Act, Assert
            Assert.True(d2 == d1);
        }
    }
}