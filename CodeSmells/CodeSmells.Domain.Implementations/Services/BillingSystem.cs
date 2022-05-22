using CodeSmells.Domain.Abstractions.Services;

namespace CodeSmells.Domain.Implementations.Services
{
    public class BillingSystem : IBillingSystem
    {
        public void NotifyAccounting()
        {
            Console.WriteLine("This is a billing system!");
        }
    }
}
