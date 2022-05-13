using DIExample.Domain.POCOs;
using DIExample.Domain.Services.Interfaces;

namespace DIExample.Domain.Services
{
    internal class ProductService : IProductService
    {
        public IEnumerable<DiscountedProduct> GetFeaturedProducts()
        {
            return new List<DiscountedProduct>();
        }
    }
}
