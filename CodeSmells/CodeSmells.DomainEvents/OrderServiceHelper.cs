using CodeSmells.DataAccessLayer;
using CodeSmells.Domain.Abstractions.EventHandlers;
using CodeSmells.Domain.Implementations.Services;
using CodeSmells.DomainEvents.EventHandlers;
using CodeSmells.DomainEvents.Events;

namespace CodeSmells.DomainEvents
{
    /// <summary>
    /// Вспомогательный класс для регистрации всех зависимостей для разного вида сервисов.
    /// </summary>
    internal class OrderServiceHelper
    {
        // Такое лучше или DI-контейнером решить или недопускать такого разделения по типам, по типу TEvent.
        public static OrderService<OrderApproved> GetApprovedOrderService()
        {
            var eventApprovedHandlers = new IEventHandler<OrderApproved>[]
            {
                new OrderApprovedAccountNotifier(new BillingSystem()),
                new OrderApprovedReceiptSender(new MessageService())
            };

            CompositeEventHandler<OrderApproved> compositeOrderApprovedHandler = new(eventApprovedHandlers);

            OrderRepository orderRepository = new();

            return new OrderService<OrderApproved>(orderRepository, compositeOrderApprovedHandler);
        }

        public static OrderService<OrderCancelled> GetCancelledOrderService()
        {
            var eventCancelledHandlers = new IEventHandler<OrderCancelled>[]
            {
                new OrderCancelledNotifier(new BillingSystem())
            };

            CompositeEventHandler<OrderCancelled> compositeOrderApprovedHandler = new(eventCancelledHandlers);

            OrderRepository orderRepository = new();

            return new OrderService<OrderCancelled>(orderRepository, compositeOrderApprovedHandler);
        }
    }
}
