using DIExample.Domain.POCOs;

namespace DIExample.Domain.Entities
{
    public class Product
    {
        public string Name { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public bool IsFeatured { get; set; }


        public DiscountedProduct GetFeaturedProduct(IUserContext userContext)
        {
            bool isPrefferedCustomer = userContext.IsInRole(Role.PreferredCustomer);

            decimal discount = isPrefferedCustomer ? 0.95m : 1;

            return new DiscountedProduct(Name, UnitPrice * discount);
        }
    }
}
