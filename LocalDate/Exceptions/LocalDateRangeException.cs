using System;

namespace LocalDate.Exceptions
{
    /// <inheritdoc />
    /// <summary>
    /// LocalDate property out of range exception
    /// </summary>
    public class LocalDateRangeException: ArgumentException
    {
        public override string Message { get; } = "Invalid date properties: make sure properties are in correct range.";

        public LocalDateRangeException() { }
    }
}