using LocalDate.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalDate.Extensions.LocalDateExtensions
{
    public static class LocalDateJulianGregorianExtension
    {
        /// <summary>
        /// Converts the LocalDate to Julian Number
        /// </summary>
        /// <param name="localDate"></param>
        /// <returns></returns>
        public static int ToJulianNumber(this LocalDate localDate) => JulianNumberUtility.JulianNumber(localDate.Year, localDate.Month, localDate.Day);

        /// <summary>
        /// Converts given Julian Number integer to LocalDate
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static LocalDate ToGregorian(this int source)
        {
            var (year, month, day) = JulianNumberUtility.GregorianDate(source);
            return new LocalDate(year, month, day);
        }
    }
}
