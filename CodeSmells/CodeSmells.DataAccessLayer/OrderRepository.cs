using CodeSmells.Domain.Abstractions.Repositories;
using CodeSmells.Domain.Entities;

namespace CodeSmells.DataAccessLayer
{
    public class OrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine("Order was saved!");
        }
    }
}
