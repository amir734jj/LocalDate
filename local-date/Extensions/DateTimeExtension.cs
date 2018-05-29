using System;

namespace LocalDate.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Converts DateTime to LocalDate
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static LocalDate ToLocalDate(this DateTime dateTime) => new LocalDate(dateTime);
    }
}
