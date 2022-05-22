using CodeSmells.Domain.Abstractions.Repositories;
using CodeSmells.Domain.Abstractions.Services;
using CodeSmells.Domain.Abstractions.FacadeServices;
using CodeSmells.Domain.Entities;

namespace CodeSmells
{
    /// <summary>
    /// Нормальная реализация <see cref="IOrderService"/>, без лишних зависимостей. Данный класс теперь соответствует SRP.
    /// </summary>
    public class NormalOrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;         // Число с 5 сократить удалось до 2.
        private readonly INotificationService _notificationService;


        public NormalOrderService(
            IOrderRepository orderRepository, 
            INotificationService notificationService)
        {
            ArgumentNullException.ThrowIfNull(orderRepository, nameof(orderRepository));
            ArgumentNullException.ThrowIfNull(notificationService, nameof(notificationService));

            _orderRepository = orderRepository;
            _notificationService = notificationService;
        }


        // Соответственно сократился и объем кода методов и число самих методов.
        public void OrderApprove(Order order)
        {
            this.UpdateOrder(order);
            this._notificationService.OrderApprove(order);
        }

        public void UpdateOrder(Order order)
        {
            order.Approve();
            this._orderRepository.Save(order);
        }
    }
}
