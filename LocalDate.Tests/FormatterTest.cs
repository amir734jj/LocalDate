using System;
using Xunit;
using LocalDate.Extensions;
using LocalDate.Extensions.LocalDateExtensions;

namespace LocalDate.Tests
{
    public class FormatterTest
    {
        private readonly LocalDate _date = new LocalDate(2018, 1, 2);

        [Fact]
        public void Test__Basic()
        {
            // Arrange
            const string formatter = "yyyy-MM-dd";

            // Act
            var str = _date.ToString(formatter);

            // Assert
            Assert.Equal("2018-01-02", str);
        }

        [Fact]
        public void Test__Padding()
        {
            // Arrange
            const string formatter = "yy-MM-dd";

            // Act
            var str = _date.ToString(formatter);

            // Assert
            Assert.Equal("18-01-02", str);
        }

        [Fact]
        public void Test__Partial()
        {
            // Arrange
            const string formatter = "M/d";

            // Act
            var str = _date.ToString(formatter);

            // Assert
            Assert.Equal("1/2", str);
        }
    }
}