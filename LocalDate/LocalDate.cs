using System;
using LocalDate.Interfaces;
using LocalDate.Extensions;
using LocalDate.Extensions.LocalDateExtensions;
using LocalDate.Models;

namespace LocalDate
{
    public class LocalDate : LocalDateStruct, ILocalDate
    {
        /// <summary>
        /// Constructor that takes: year, month and day
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="day"></param>
        public LocalDate(int year, int month, int day) : base(year, month, day)
        {
            ValidateLocalDate(year, month, day);
        }

        /// <summary>
        /// Constructor that takes a DateTime
        /// </summary>
        /// <param name="dateTime"></param>
        public LocalDate(DateTime dateTime) : this(dateTime.Year, dateTime.Month, dateTime.Day)
        {

        }

        /// <summary>
        /// Adds two LocalDate together
        /// </summary>
        /// <param name="localDate1"></param>
        /// <param name="localDate2"></param>
        /// <returns></returns>
        public static LocalDate operator +(LocalDate localDate1, LocalDate localDate2) => (localDate1.ToJulianNumber() + localDate2.ToJulianNumber()).ToGregorian();

        /// <summary>
        /// Subtracts two LocalDate together
        /// </summary>
        /// <param name="localDate1"></param>
        /// <param name="localDate2"></param>
        /// <returns></returns>
        public static LocalDate operator -(LocalDate localDate1, LocalDate localDate2) => (localDate1.ToJulianNumber() - localDate2.ToJulianNumber()).ToGregorian();

        /// <summary>
        /// Subtract given days from LocalDate
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public ILocalDate SubtractDays(int days) => (this.ToJulianNumber() - days).ToGregorian();

        /// <summary>
        /// Subtract given months from LocalDate
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public ILocalDate SubtractMonths(int months)
        {
            var temp = Month - months;
            return temp < 0 ? new LocalDate(Year, temp.ModPositive(12), Day).SubtractYears((int)Math.Floor(temp / 12.0) * -1) : new LocalDate(Year, temp, Day);
        }

        /// <summary>
        /// Subtract given years from LocalDate
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public ILocalDate SubtractYears(int years) => new LocalDate(Year - years, Month, Day);

        /// <summary>
        /// Adds a given days to LocalDate
        /// </summary>
        /// <param name="days"></param>
        /// <returns></returns>
        public ILocalDate AddDays(int days) => (this.ToJulianNumber() + days).ToGregorian();
        /// <summary>
        /// Adds given months to LocalDate
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public ILocalDate AddMonths(int months)
        {
            var temp = Month + months;
            return temp > 12 ? new LocalDate(Year, temp % 12, Day).AddYears(temp / 12) : new LocalDate(Year, temp, Day);
        }

        /// <summary>
        /// Adds given years to LocalYear
        /// </summary>
        /// <param name="years"></param>
        /// <returns></returns>
        public ILocalDate AddYears(int years) => new LocalDate(Year + years, Month, Day);

        /// <summary>
        /// Explicit cast from DateTime to LocalDate
        /// </summary>
        /// <param name="dateTime"></param>
        public static explicit operator LocalDate(DateTime dateTime) => new LocalDate(dateTime);

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