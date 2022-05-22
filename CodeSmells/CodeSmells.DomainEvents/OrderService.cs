using CodeSmells.Domain.Abstractions.EventHandlers;
using CodeSmells.Domain.Abstractions.Repositories;
using CodeSmells.Domain.Abstractions.Services;
using CodeSmells.Domain.Entities;

namespace CodeSmells.DomainEvents
{
    // Аналог CodeSmells.NormalOrderService, но используя доменные события вместо фасадных сервисов.
    public class OrderService<TEvent> : IOrderService
    {
        private readonly IEventHandler<TEvent> _approvedHandler; // Как видно результат тот же, что и в исходном классе.
        private readonly IOrderRepository _orderRepository;


        public OrderService(IOrderRepository orderRepository, IEventHandler<TEvent> approvedHandler)
        {
            ArgumentNullException.ThrowIfNull(orderRepository, nameof(orderRepository));
            ArgumentNullException.ThrowIfNull(approvedHandler, nameof(approvedHandler));

            this._approvedHandler = approvedHandler;
            this._orderRepository = orderRepository;
        }


        public void OrderApprove(Order order)
        {
            this.UpdateOrder(order);

            // С небольшой доработкой.
            TEvent @event = (TEvent)Activator.CreateInstance(typeof(TEvent), new object[] { order.Id })!;

            this._approvedHandler.Handle(@event);
        }

        public void UpdateOrder(Order order)
        {
            order.Approve();
            this._orderRepository.Save(order);
        }
    }
}
