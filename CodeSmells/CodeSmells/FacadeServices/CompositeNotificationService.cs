using CodeSmells.Domain.Abstractions.FacadeServices;
using CodeSmells.Domain.Entities;

namespace CodeSmells.FacadeServices
{
    /// <summary>
    /// Компоновщик сервисов уведомления различных систем.
    /// </summary>
    public class CompositeNotificationService : INotificationService
    {
        private readonly IEnumerable<INotificationService> _services;


        public CompositeNotificationService(IEnumerable<INotificationService> services)
        {
            ArgumentNullException.ThrowIfNull(services, nameof(services));

            _services = services;
        }


        public void OrderApprove(Order order)
        {
            foreach (INotificationService service in _services)
            {
                service.OrderApprove(order);
            }
        }
    }
}
