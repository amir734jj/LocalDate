using System;

namespace LocalDate.Extensions
{
    public static class DoubleExtension
    {
        public static int TruncateToInt(this double number) => (int) Math.Truncate(number);

        public static (double fractional, int integral) Modf(this double number)
        {
            var integral = number.TruncateToInt();
            var fractional = number - integral;
            return (fractional, integral);
        }
    }
}