using DIExample.Domain.POCOs;
using DIExample.Domain.Repositories;
using DIExample.Domain.Services.Interfaces;

namespace DIExample.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserContext _userContext;


        public ProductService(IProductRepository productRepository, IUserContext userContext)
        {
            ArgumentNullException.ThrowIfNull(productRepository, nameof(productRepository));
            ArgumentNullException.ThrowIfNull(userContext, nameof(userContext));

            _productRepository = productRepository;
            _userContext = userContext;
        }


        public IEnumerable<DiscountedProduct> GetFeaturedProducts()
        {
            var products = _productRepository
                .GetFeaturedProducts()
                .Select(x => x.ApplyDiscountFor(_userContext));

            return products;
        }
    }
}
