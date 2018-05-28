using System.Linq;
using LocalDate.Utilities;
using Xunit;

namespace LocalDate.Tests.UtilityTests
{
    public class LeapYearTest
    {
        private readonly int[] _leapYear = {
            1904, 1908, 1912, 1916, 1920, 1924, 1928, 1932, 1936, 1940, 1944, 1948, 1952, 1956, 1960,
            1964, 1968, 1972, 1976, 1980, 1984, 1988, 1992, 1996, 2000, 2004, 2008, 2012, 2016, 2020
        };
        
        private readonly int[] _nonleapYear = {
            1905, 1909, 1913, 1917, 1921, 1925, 1929, 1933, 1937, 1941, 1945, 1949, 1953, 1957, 1961,
            1965, 1969, 1973, 1977, 1981, 1985, 1989, 1993, 1997, 2001, 2005, 2009, 2013, 2017, 2021
        };
        
        [Fact]
        public void Test__LeapYear()
        {
            // Arrange, Act, Assert
            Assert.Equal(_leapYear.Length, _leapYear.Where(YearUtility.IsLeapYear).Count());
        }

        [Fact]
        public void Test__NonLeapYear()
        {
            // Arrange, Act, Assert
            Assert.Empty(_nonleapYear.Where(YearUtility.IsLeapYear));
        }
    }
}