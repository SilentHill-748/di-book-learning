namespace ConsoleExample.Domain
{
    public class Currency
    {
        public Currency(string code)
        {
            if (string.IsNullOrEmpty(code))
                throw new ArgumentNullException(nameof(code), "Currency code wasn't be null or empty!");

            Code = code;
        }


        public string Code { get; set; }
        public decimal Rate { get; set; }

        public static Currency DollarCurrency => new("USD");


        public override bool Equals(object? obj)
        {
            if (obj is not null && obj is Currency otherCurrency)
            {
                return otherCurrency.Code.Equals(this.Code); 
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Code, Rate);
        }
    }
}
