using DIExample.Domain.POCOs;

namespace DIExample.Domain.Abstractions
{
    public interface IProductService
    {
        IEnumerable<DiscountedProduct> GetFeaturedProducts();
    }
}
