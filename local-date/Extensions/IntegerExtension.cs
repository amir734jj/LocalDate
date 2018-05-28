namespace LocalDate.Extensions
{
    public static class IntegerExtension
    {
        /// <summary>
        /// Positive modulo
        /// </summary>
        /// <param name="source"></param>
        /// <param name="modulo"></param>
        /// <returns></returns>
        public static int ModPositive(this int source, int modulo)
        {
            var result = source % modulo;
            while (result < 0) result += modulo;
            return result;
        } 
    }
}