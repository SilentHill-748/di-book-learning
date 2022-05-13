namespace DIExample.Domain.POCOs
{
    public class DiscountedProduct
    {
        public DiscountedProduct(string name, decimal unitPrice)
        {
            ArgumentNullException.ThrowIfNull(name, nameof(name));

            Name = name;
            UnitPrice = unitPrice;
        }

        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
