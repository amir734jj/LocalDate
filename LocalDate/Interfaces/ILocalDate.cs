namespace LocalDate.Interfaces
{
    public interface ILocalDate
    {
        ILocalDate AddDays(int days);
        
        ILocalDate AddMonths(int months);
        
        ILocalDate AddYears(int years);

        ILocalDate SubtractDays(int days);

        ILocalDate SubtractMonths(int months);

        ILocalDate SubtractYears(int years);
    }
}