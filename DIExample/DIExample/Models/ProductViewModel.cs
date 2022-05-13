using System.Globalization;

using DIExample.Domain.POCOs;

namespace DIExample.Models
{
    public class ProductViewModel
    {
        private static readonly CultureInfo PriceCulture = new("en-US");


        public ProductViewModel(DiscountedProduct product)
        {
            SummaryText = string.Format(PriceCulture, "{0} ({1:C})", product.Name, product.UnitPrice);
        }


        public string SummaryText { get; set; }
    }
}
