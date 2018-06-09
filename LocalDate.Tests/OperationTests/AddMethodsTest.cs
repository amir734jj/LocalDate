using System;
using Xunit;

namespace LocalDate.Tests.OperationTests
{
    public class AddMethodsTest
    {
        [Fact]
        public void Test__AddDays()
        {
            // Arrange
            var localDate = new LocalDate(2010, 1, 2);
            var expected = new LocalDate(2010, 1, 27);

            // Act
            localDate = localDate.AddDays(25) as LocalDate;

            // Assert
            Assert.Equal(expected, localDate);
        }

        [Fact]
        public void Test__AddDaysComplex()
        {
            // Arrange
            var localDate = new LocalDate(2010, 1, 2);
            var expected = new LocalDate(2010, 5, 18);

            // Act
            localDate = localDate.AddDays(136) as LocalDate;

            // Assert
            Assert.Equal(expected, localDate);
        }

        [Fact]
        public void Test__AddMonths()
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
        public void Test__AddMonthsComplex()
        {
            // Arrange
            var localDate = new LocalDate(2010, 10, 2);
            var expected = new LocalDate(2011, 3, 2);

            // Act
            localDate = localDate.AddMonths(5) as LocalDate;

            // Assert
            Assert.Equal(expected, localDate);
        }

        [Fact]
        public void Test__AddYears()
        {
            // Arrange
            var localDate = new LocalDate(2010, 1, 2);
            var expected = new LocalDate(2015, 1, 2);

            // Act
            localDate = localDate.AddYears(5) as LocalDate;

            // Assert
            Assert.Equal(expected, localDate);
        }
    }
}