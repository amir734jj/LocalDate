using System;
using LocalDate.Enums;

namespace LocalDate.Utilities
{
    public static class YearUtility
    {
        /// <summary>
        /// Tests whether if year is a leap year or not
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public static bool IsLeapYear(int year) => year >= 1583 && (year % 4 == 0 && year % 100 != 0 || year % 400 == 0);

        /// <summary>
        /// Notes:
        ///     January - 31 days
        ///     February - 28 days in a common year and 29 days in leap years
        ///     March - 31 days
        ///     April - 30 days
        ///     May - 31 days
        ///     June - 30 days
        ///     July - 31 days
        ///     August - 31 days
        ///     September - 30 days
        ///     October - 31 days
        ///     November - 30 days
        ///     December - 31 day
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static int NumberOfDaysInMonth(int month, int year)
        {
            var monthEnum = (MonthEnum) month;
            
            switch (monthEnum)
            {
                case MonthEnum.January:
                    return 31;
                case MonthEnum.February:
                    return IsLeapYear(year) ? 29 : 28;
                case MonthEnum.March:
                    return 31;
                case MonthEnum.April:
                    return 30;
                case MonthEnum.May:
                    return 31;
                case MonthEnum.June:
                    return 30;
                case MonthEnum.July:
                    return 31;
                case MonthEnum.August:
                    return 31;
                case MonthEnum.September:
                    return 30;
                case MonthEnum.October:
                    return 31;
                case MonthEnum.November:
                    return 30;
                case MonthEnum.December:
                    return 31;
                default:
                    throw new ArgumentOutOfRangeException(nameof(month));
            }
        }
    }
}