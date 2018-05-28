using Xunit;

namespace LocalDate.Tests.OperationTests
{
    public class SubtractMethodTest
    {
        [Fact]
        public void Test__SubtractMonths()
        {
            // Arrange
            var localDate = new LocalDate(2010, 1, 2);
            var expected = new LocalDate(2010, 6, 2);
            
            // Act
            localDate = localDate.AddMonths(5) as LocalDate;

            // Assert
            Assert.Equal(expected, localDate);
        }
        
        [Fact]
        public void Test__SubtractMonthsComplex()
        {
            // Arrange
            var localDate = new LocalDate(2011, 6, 2);
            var expected = new LocalDate(2010, 3, 2);
            
            // Act
            localDate = localDate.SubtractMonths(9) as LocalDate;

            // Assert
            Assert.Equal(expected, localDate);
        }
        
        [Fact]
        public void Test__SubtractYears()
        {
            // Arrange
            var localDate = new LocalDate(2015, 1, 2);
            var expected = new LocalDate(2010, 1, 2);
            
            // Act
            localDate = localDate.SubtractYears(5) as LocalDate;

            // Assert
            Assert.Equal(expected, localDate);
        }
    }
}