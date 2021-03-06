﻿using LocalDate.Utilities;
using Xunit;

namespace LocalDate.Tests.UtilityTests
{
    public class JulianNumberTest
    {
        [Fact]
        public void Test__JulianNumber()
        {
            // Arrange, Act
            var number = JulianNumberUtility.JulianNumber(2010, 1, 2);

            // Assert
            Assert.Equal((decimal) 2455199, number);
        }
        
        [Fact]
        public void Test__GregorianDate()
        {
            // Arrange
            var (year, month, day) = (2010, 1, 2);
            
            // Act
            var number = JulianNumberUtility.GregorianDate(2455199);

            // Assert
            Assert.Equal((year, month, day), number);
        }

        [Fact]
        public void Test__Cycle()
        {
            // Arrange
            var (expectedYear, expectedMonth, expectedDay) = (2010, 1, 2);

            // Act
            var (year, month, day) = JulianNumberUtility.GregorianDate(JulianNumberUtility.JulianNumber(expectedYear, expectedMonth, expectedDay));

            // Assert
            Assert.Equal((expectedYear, expectedMonth, expectedDay), (year, month, day));
        }
    }
}