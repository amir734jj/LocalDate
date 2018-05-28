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
        public static decimal JulianNumber(int year, int month, int day)
        {
            return julianDayNumber(day, month, year);

            //int yearp, monthp;
            //int b;

            //if (month == 1 || month == 2)
            //{
            //    yearp = year - 1;
            //    monthp = month + 12;
            //}
            //else
            //{
            //    yearp = year;
            //    monthp = month;
            //}

            //// this checks where we are in relation to October 15, 1582, the beginning of the Gregorian calendar.
            //if ((year < 1582) ||
            //    (year == 1582 && month < 10) ||
            //    (year == 1582 && month == 10 && day < 15))
            //{
            //    // before start of Gregorian calendar
            //    b = 0;
            //}
            //else
            //{
            //    // after start of Gregorian calendar
            //    var a = (yearp / 100.0).TruncateToInt();
            //    b = 2 - a + (a / 4.0).TruncateToInt();
            //}

            //var c = yearp < 0 ? ((365.25 * yearp) - 0.75).TruncateToInt() : (365.25 * yearp).TruncateToInt();

            //var d = (30.6001 * (monthp + 1)).TruncateToInt();
            //var julianNumber = b + c + d + day + 1720994.5;
            //return julianNumber;
        }

        /// <summary>
        /// Converts Julian number to year, month and day
        /// </summary>
        /// <param name="julianNumber"></param>
        /// <returns></returns>
        public static (int year, int month, int day) GregorianDate(decimal julianNumber)
        {
            var x = julianDateToGregorian((decimal) julianNumber);
            return x;

            //int b, month, year;
    
            //(double f, int I) = julianNumber.Modf();

            //var a = ((I - 1867216.25) / 36524.25).TruncateToInt();

            //if (I > 2299160)
            //{
            //    b = I + 1 + a - (a / 4.0).TruncateToInt();
            //}
            //else
            //{
            //    b = I;
            //}

            //var c = b + 1524;

            //var d = ((c - 122.1) / 365.25).TruncateToInt();

            //var e = (365.25 * d).TruncateToInt();

            //var g = ((c - e) / 30.6001).TruncateToInt();

            //var day = c - e + f - (30.6001 * g).TruncateToInt();

            //if (g < 13.5)
            //{
            //    month = g - 1;
            //}
            //else
            //{
            //    month = g - 13;
            //}

            //if (month > 2.5)
            //{
            //    year = d - 4716;
            //}
            //else
            //{
            //    year = d - 4715;
            //}

            //return (year, month, (int) Math.Ceiling(day));
        }


        private static decimal julianDayNumber(decimal d, decimal m, decimal y)
        {
            decimal a, b, c, e, f;

            if (m == 1 || m == 2)
            {
                y -= 1;
                m += 12;
            }
            a = Math.Truncate(y / 100);
            b = Math.Truncate(a / 4);
            c = 2 - a + b;
            e = Math.Truncate((365.25m * (y + 4716)));
            f = Math.Truncate((30.6001m * (m + 1)));

            return (c + d + e + f - 1524.5m);
        }

        public static decimal dayFraction(decimal h, decimal m, decimal s)
        {
            return (h / 24) + (m / 1440) + (s / 86400);
        }

        private static decimal julianDate(decimal d, decimal m, decimal y, decimal hh, decimal mm, decimal ss)
        {
            return Math.Round(julianDayNumber(d, m, y) + dayFraction(hh, mm, ss), 6);
        }

        private static decimal modifiedJulianDate(decimal d, decimal m, decimal y, decimal hh, decimal mm, decimal ss)
        {
            return julianDate(d, m, y, hh, mm, ss) - 2400000.5m;
        }

        private static (int year, int month, int k) julianDateToGregorian(decimal jd)
        {
            int l, n, i, j, k;

            l = (int)jd + 68569;
            n = 4 * l / 146097;
            l = l - (146097 * n + 3) / 4;
            i = 4000 * (l + 1) / 1461001;
            l = l - 1461 * i / 4 + 31;
            j = 80 * l / 2447;
            k = l - 2447 * j / 80;
            l = j / 11;
            j = j + 2 - 12 * l;
            i = 100 * (n - 49) + i + l;

            return (i, j, k);
        }
    }
}