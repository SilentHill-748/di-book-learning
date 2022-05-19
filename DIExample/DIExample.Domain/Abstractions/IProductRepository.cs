using DIExample.Domain.Entities;

namespace DIExample.Domain.Abstractions
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetFeaturedProducts();
    }
}
