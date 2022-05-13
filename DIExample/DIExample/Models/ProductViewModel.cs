using System.Globalization;

namespace DIExample.Models
{
    public class ProductViewModel
    {
        private static readonly CultureInfo PriceCulture = new("en-US");


        public ProductViewModel(string name, decimal unitPrice)
        {
            SummaryText = string.Format(PriceCulture, "{0} ({1:C})", name, unitPrice);
        }


        public string SummaryText { get; set; }
    }
}
