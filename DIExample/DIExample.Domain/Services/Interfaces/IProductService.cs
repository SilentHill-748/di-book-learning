using DIExample.Domain.POCOs;

namespace DIExample.Domain.Services.Interfaces
{
    public interface IProductService
    {
        IEnumerable<DiscountedProduct> GetFeaturedProducts();
    }
}
