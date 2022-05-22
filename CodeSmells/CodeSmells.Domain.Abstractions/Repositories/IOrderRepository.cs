using CodeSmells.Domain.Entities;

namespace CodeSmells.Domain.Abstractions.Repositories
{
    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
