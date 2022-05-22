using CodeSmells.Domain.Abstractions.EventHandlers;
using CodeSmells.Domain.Abstractions.Services;
using CodeSmells.DomainEvents.Events;

namespace CodeSmells.DomainEvents.EventHandlers
{
    /// <summary>
    /// Обработчик события утверждения заказа, уведомляющий пользователя, используя <see cref="IBillingSystem"/>.
    /// Является аналогом фасадному сервису CodeSmells.FacadeServices.AccountNotifier
    /// </summary>
    public class OrderApprovedAccountNotifier : IEventHandler<OrderApproved>
    {
        private readonly IBillingSystem _billingSystem;


        public OrderApprovedAccountNotifier(IBillingSystem billingSystem)
        {
            ArgumentNullException.ThrowIfNull(billingSystem, nameof(billingSystem));

            this._billingSystem = billingSystem;
        }


        public void Handle(OrderApproved e)
        {
            this._billingSystem.NotifyAccounting();
        }
    }
}
