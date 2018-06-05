using System.Text.RegularExpressions;

namespace LocalDate.Extensions.LocalDateExtensions
{
    public static class LocalDateFormatterExtensions
    {
        /// <summary>
        /// Local date to string given a formatter
        /// </summary>
        /// <param name="localDate"></param>
        /// <param name="formatter"></param>
        /// <returns></returns>
        public static string ToString(this LocalDate localDate, string formatter)
        {
            var regex = new Regex("((?<month>[M]{1,2})|(?<day>[d]{1,2})|(?<year>[y]{1,4})|([^a-zA-Z]))*");

            var match = regex.Match(formatter);

            // No match, just return
            if (!match.Success) return string.Empty;

            // Match the named groups
            var day = match.Groups["day"]?.Value;
            var month = match.Groups["month"]?.Value;
            var year = match.Groups["year"]?.Value;

            var result = formatter;

            // Format properties
            result = !string.IsNullOrEmpty(day) ? result.Replace(day, localDate.Day.ToString().PadLeft(day.Length, '0').GetLast(day.Length)) : result;

            result = !string.IsNullOrEmpty(month) ? result.Replace(month, localDate.Month.ToString().PadLeft(month.Length, '0').GetLast(month.Length)) : result;

            result = !string.IsNullOrEmpty(year) ? result.Replace(year, localDate.Year.ToString().PadLeft(year.Length, '0').GetLast(year.Length)) : result;

            return result;
        }
    }
}
