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
        public static int JulianNumber(int year, int month, int day) => (1461 * (year + 4800 + (month - 14) / 12)) / 4 +
                                                                            (367 * (month - 2 - 12 * ((month - 14) / 12))) / 12 -
                                                                            (3 * ((year + 4900 + (month - 14) / 12) / 100)) / 4 +
                                                                            day - 32075;

        /// <summary>
        /// Converts Julian number to year, month and day
        /// </summary>
        /// <param name="julianNumber"></param>
        /// <returns></returns>
        public static (int year, int month, int day) GregorianDate(int julianNumber)
        {
            var l = julianNumber + 68569;
            var n = (4 * l) / 146097;
            l = l - (146097 * n + 3) / 4;
            var i = (4000 * (l + 1)) / 1461001;
            l = l - (1461 * i) / 4 + 31;
            var j = (80 * l) / 2447;
            var d = l - (2447 * j) / 80;
            l = j / 11;
            var m = j + 2 - (12 * l);
            var y = 100 * (n - 49) + i + l;

            return (y, m, d);
        }
    }
}