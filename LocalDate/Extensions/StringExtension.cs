using System;

namespace LocalDate.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns last n characters of a string
        /// </summary>
        /// <param name="source"></param>
        /// <param name="tailLength"></param>
        /// <returns></returns>
        public static string GetLast(this string source, int tailLength)
        {
            return tailLength >= source.Length ? source : source.Substring(source.Length - tailLength);
        }

        /// <summary>
        /// Converts string to CammelCase
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToUpperCamelCase(this string source) => Char.ToUpper(source[0]) + source.Substring(1);
    }
}