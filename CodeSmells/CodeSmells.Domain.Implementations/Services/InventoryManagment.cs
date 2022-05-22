using CodeSmells.Domain.Abstractions.Services;

namespace CodeSmells.Domain.Implementations.Services
{
    public class InventoryManagment : IInventoryManagment
    {
        public void NotifyWarehouses()
        {
            Console.WriteLine("This is a inventory managment!");
        }
    }
}
