using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LocalDate.Extensions;
using LocalDate.Constants;
using LocalDate.Enums;

namespace LocalDate.Factories
{
    public static class LocalDateFactory
    {
        private static readonly string[] NumericPatterns = {
            @"(?<month>\d{1,2})[^\d]*(?<day>\d{1,2})[^\d]*(?<year>\d{1,4})",
        };

        private static readonly string[] LetterPatterns =
        {
            @"(?<month>January|February|March|April|May|June|July|August|September|October|November|December)[^\d\w]*(?<day>\d{1,2})[^\d\w]*(?<year>\d{1,4})",
        };

        /// <summary>
        /// Parse local date given a pattern
        /// </summary>
        /// <param name="str"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static LocalDate ParseLocalDate(string str, string pattern = null)
        {
            var patterns = pattern == null ? GetAppropriatePattern(str) : new[] {pattern};
            LocalDate result = null;
            
            patterns.ForEach(x =>
            {
                var regex = new Regex(x, RegexOptions.IgnoreCase);
                
                var match = regex.Match(str);

                // No match, just return
                if (!match.Success) return;

                // Match the named groups
                var day = match.Groups["day"]?.Value;
                var month = match.Groups["month"]?.Value;
                var year = match.Groups["year"]?.Value;

                if (string.IsNullOrEmpty(year) || string.IsNullOrEmpty(month) || string.IsNullOrEmpty(day))
                {
                    return;
                }

                // Safely convert named month to month integer
                if (Regex.IsMatch(month, @"^[a-zA-Z]+$"))
                {
                    month = month.ToUpperCamelCase();
                    month = Enum.GetNames(typeof(MonthEnum)).FirstOrDefault(m => m == month);
                    month = string.IsNullOrEmpty(month) ? "0" : ((int) Enum.Parse(typeof(MonthEnum), month)).ToString();
                }

                result = new LocalDate(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));
            });

            return result ?? LocalDateConstants.ZeroLocalDate;
        }

        /// <summary>
        /// Retruns appropriate pattern given string
        /// </summary>
        /// <param name="localDateStr"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetAppropriatePattern(string localDateStr)
        {
            if (Regex.IsMatch(localDateStr, @"[a-zA-Z]"))
            {
                return LetterPatterns;
            }
            else
            {
                return NumericPatterns;
            }
        }
    }
}