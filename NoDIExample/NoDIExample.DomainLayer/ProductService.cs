using NoDIExample.DataLayer;
using NoDIExample.DataLayer.Entities;

namespace NoDIExample.DomainLayer
{
    public class ProductService
    {
        private readonly CommerceContext _commerceContext;


        public ProductService()
        {
            this._commerceContext = new CommerceContext();
        }


        public IEnumerable<Products> GetFeaturedProducts(bool isCustomerPreferred)
        {
            decimal discount = isCustomerPreferred ? 0.95m : 1;

            var products = _commerceContext.Products
                .AsEnumerable()
                .Where(x => x.IsFeatured);

            return products.Select(x => new Products()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                IsFeatured = x.IsFeatured,
                UnitPrice = x.UnitPrice * discount
            });
        }
    }
}
