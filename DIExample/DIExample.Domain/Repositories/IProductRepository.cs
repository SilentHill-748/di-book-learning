using DIExample.Domain.Entities;

namespace DIExample.Domain.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetFeaturedProducts();
    }
}
