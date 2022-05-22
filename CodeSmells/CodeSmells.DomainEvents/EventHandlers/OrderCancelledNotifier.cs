using CodeSmells.Domain.Abstractions.EventHandlers;
using CodeSmells.Domain.Abstractions.Services;
using CodeSmells.DomainEvents.Events;

namespace CodeSmells.DomainEvents.EventHandlers
{
    /// <summary>
    /// Обработчик события отмены заказа, уведомляющий пользователя, используя <see cref="IBillingSystem"/>.
    /// Является аналогом фасадному сервису CodeSmells.FacadeServices.AccountNotifier
    /// </summary>
    public class OrderCancelledNotifier : IEventHandler<OrderCancelled>
    {
        private readonly IBillingSystem _billingSystem;


        public OrderCancelledNotifier(IBillingSystem billingSystem)
        {
            ArgumentNullException.ThrowIfNull(billingSystem, nameof(billingSystem));

            this._billingSystem = billingSystem;
        }


        public void Handle(OrderCancelled e)
        {
            this._billingSystem.NotifyAccounting();
        }
    }
}
