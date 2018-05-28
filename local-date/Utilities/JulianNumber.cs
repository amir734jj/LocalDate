using System;
using LocalDate.Extensions;

namespace LocalDate.Utilities
{
    public static class JulianNumberUtility
    {
        /// <summary>
        /// Converts year, month and day to a Julian number
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <returns></returns>
        public static double JulianNumber(int year, int month, int day)
        {
            int yearp, monthp;
            int b;

            if (month == 1 || month == 2)
            {
                yearp = year - 1;
                monthp = month + 12;
            }
            else
            {
                yearp = year;
                monthp = month;
            }

            // this checks where we are in relation to October 15, 1582, the beginning of the Gregorian calendar.
            if ((year < 1582) ||
                (year == 1582 && month < 10) ||
                (year == 1582 && month == 10 && day < 15))
            {
                // before start of Gregorian calendar
                b = 0;
            }
            else
            {
                // after start of Gregorian calendar
                var a = (yearp / 100.0).TruncateToInt();
                b = 2 - a + (a / 4.0).TruncateToInt();
            }

            var c = yearp < 0 ? ((365.25 * yearp) - 0.75).TruncateToInt() : (365.25 * yearp).TruncateToInt();

            var d = (30.6001 * (monthp + 1)).TruncateToInt();
            var julianNumber = b + c + d + day + 1720994.5;
            return julianNumber;
        }

        /// <summary>
        /// Converts Julian number to year, month and day
        /// </summary>
        /// <param name="julianNumber"></param>
        /// <returns></returns>
        public static (int year, int month, int day) GregorianDate(double julianNumber)
        {
            int b, month, year;
    
            (double f, int I) = julianNumber.Modf();

            var a = ((I - 1867216.25) / 36524.25).TruncateToInt();

            if (I > 2299160)
            {
                b = I + 1 + a - (a / 4.0).TruncateToInt();
            }
            else
            {
                b = I;
            }

            var c = b + 1524;

            var d = ((c - 122.1) / 365.25).TruncateToInt();

            var e = (365.25 * d).TruncateToInt();

            var g = ((c - e) / 30.6001).TruncateToInt();

            var day = c - e + f - (30.6001 * g).TruncateToInt();

            if (g < 13.5)
            {
                month = g - 1;
            }
            else
            {
                month = g - 13;
            }

            if (month > 2.5)
            {
                year = d - 4716;
            }
            else
            {
                year = d - 4715;
            }

            return (year, month, (int) Math.Ceiling(day));
        }
    }
}