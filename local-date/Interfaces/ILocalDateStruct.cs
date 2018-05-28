namespace LocalDate.Interfaces
{
    /// <summary>
    /// Basic properties of a LocalDate type
    /// </summary>
    public interface ILocalDateStruct
    {
        int Year { get; }

        int Month { get; }

        int Day { get; }
    }
}
