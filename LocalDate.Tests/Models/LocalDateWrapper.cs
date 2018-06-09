namespace LocalDate.Tests.Models
{
    public class LocalDateWrapper
    {
        public LocalDate Date { get; set; }
            
        public string Name { get; set; }

        protected bool Equals(LocalDateWrapper other)
        {
            return Equals(Date, other.Date) && string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((LocalDateWrapper) obj);
        }
    }
}