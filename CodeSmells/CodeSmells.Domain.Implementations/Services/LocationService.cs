using CodeSmells.Domain.Abstractions.Services;

namespace CodeSmells.Domain.Implementations.Services
{
    public class LocationService : ILocationService
    {
        public void FindWarehouses()
        {
            Console.WriteLine("This is a location service!");
        }
    }
}
