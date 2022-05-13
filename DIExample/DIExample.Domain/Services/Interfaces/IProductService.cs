using DIExample.Domain.Entities;

namespace DIExample.Domain.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<DiscountedProduct> GetFeaturedProducts();
    }
}
