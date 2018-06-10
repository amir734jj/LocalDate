using System;
using Xunit;
using AutoFixture;
using LocalDate.Extensions.LocalDateExtensions;

namespace LocalDate.Tests.CastTests
{
    public class CastingTest: LocalDateFixture
    {
        [Fact]
        public void Test__DateTimeToLocalDate()
        {
            // Arrange
            var dateTime = Fixture.Create<DateTime>();

            // Act
            var result = ((LocalDate) dateTime).ToDateTime();

            // Assert
            Assert.Equal(dateTime.Date, result);
        }
    }
}