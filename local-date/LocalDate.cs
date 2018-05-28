using System;
using LocalDate.Interfaces;
using LocalDate.Utilities;
using LocalDate.Extensions;
using LocalDate.Models;

namespace LocalDate
{
    public class LocalDate: LocalDateStruct, ILocalDate
    {
        public LocalDate(int year, int month, int day) : base(year, month, day)
        {
            ValidateLocalDate(year, month, day);
        }

        public static LocalDate operator +(LocalDate c1, LocalDate c2)
        {
            return Constants.LocalDateConstants.ZeroLocalDate;
        }

        public ILocalDate SubtractDays(int days)
        {
            var julianNumber = JulianNumberUtility.JulianNumber(Year, Month, Day);
            julianNumber -= days;

            int year, month;
            (year, month, days) = JulianNumberUtility.GregorianDate(julianNumber);
            return new LocalDate(year, month, days);
        }

        public ILocalDate SubtractMonths(int months)
        {
            var temp = Month - months;
            return temp < 0 ? new LocalDate(Year, temp.ModPositive(12), Day).SubtractYears((int) Math.Floor(temp / 12.0) * -1) : new LocalDate(Year, temp, Day);
        }

        public ILocalDate SubtractYears(int years) => new LocalDate(Year - years, Month, Day);

        /// <summary>
        /// Adds a given days to LocalDate
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public ILocalDate AddDays(int days)
        {
            var julianNumber = JulianNumberUtility.JulianNumber(Year, Month, Day);
            julianNumber += days;

            int year, month;
            (year, month, days) = JulianNumberUtility.GregorianDate(julianNumber);
            return new LocalDate(year, month, days);
        }

        /// <summary>
        /// Adds given month to LocalDate
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public ILocalDate AddMonths(int months)
        {
            var temp = Month + months;
            return temp > 12 ? new LocalDate(Year, temp % 12, Day).AddYears(temp / 12) : new LocalDate(Year, temp, Day);
        }

        /// <summary>
        /// Adds given year to LocalYear
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public ILocalDate AddYears(int years) => new LocalDate(Year + years, Month, Day);

        /// <summary>
        /// Validate date properties are in correct range, roughly
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        /// <exception cref="ArgumentException"></exception>
        private static void ValidateLocalDate(int year, int month, int day)
        {
            if (year < 0 || month < 0 || month > 12 || day < 0 || day > 31)
            {
                throw new ArgumentException("Invalid date properties: make sure properties are in correct range.");
            }
        }
    }
}