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
            decimal a, b, c, e, f;

            if (month == 1 || month == 2)
            {
                year -= 1;
                month += 12;
            }

            a = Math.Truncate((decimal)year / 100);
            b = Math.Truncate(a / 4);
            c = 2 - a + b;
            e = Math.Truncate((365.25m * (year + 4716)));
            f = Math.Truncate((30.6001m * (month + 1)));

            return (c + day + e + f - 1524.5m);
        }

        /// <summary>
        /// Converts Julian number to year, month and day
        /// </summary>
        /// <param name="julianNumber"></param>
        /// <returns></returns>
        public static (int year, int month, int day) GregorianDate(decimal julianNumber)
        {
           // julianNumber = (julianNumber);
            int l, n, i, j, k;

            l = (int)julianNumber + 68569;
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