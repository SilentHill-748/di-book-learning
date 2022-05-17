// TODO: Абстракции домена лучше выделить в отдельную сборку Domain.Abstractions и уже эту сборку юзать.
// В книге 'Внедрение зависимостей на платформе .NET' авторы упоминули, что абстракцию IProductService надо
// реализовать в отдельной сборке. Я предполагаю, что все абстракции домена надо вынести в отдельную сборку
// Domain.Abstractions.
using DIExample.Domain.Repositories;
using DIExample.Domain.Entities;

namespace DIExample.Data.Repositories
{
    public class SqlProductsRepository : IProductRepository
    {
        private readonly CommerceContext _dbContext;


        // Атворы книг пишут, что нужно использовать абстракцию к нестабильным зависимостям,
        // но в примере с использованием технологий DI они явно указали контекст данных.
        // По идее, нам может потребоваться в будущем другой контекст.
        // Лучше же использовать дженерик версию репозиториев? Для следования примеру я опустил этот вопрос.
        public SqlProductsRepository(CommerceContext dbContext)
        {
            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));

            _dbContext = dbContext;
        }


        public IEnumerable<Product> GetFeaturedProducts()
        {
            return _dbContext.Products
                .Where(product => product.IsFeatured);
        }
    }
}
