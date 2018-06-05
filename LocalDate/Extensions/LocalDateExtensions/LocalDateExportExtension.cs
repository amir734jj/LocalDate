using System;

namespace LocalDate.Extensions.LocalDateExtensions
{
    public static class LocalDateExportExtensions
    {
        /// <summary>
        /// To native C# DateTime
        /// </summary>
        /// <param name="localDate"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this LocalDate localDate) => DateTime.Parse(localDate.ToString());
        
        /// <summary>
        /// To integer array
        /// </summary>
        /// <param name="localDate"></param>
        /// <returns></returns>
        public static int[] ToArray(this LocalDate localDate) => new[] { localDate.Year, localDate.Month, localDate.Day };
    }
}