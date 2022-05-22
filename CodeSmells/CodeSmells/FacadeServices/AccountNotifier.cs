using CodeSmells.Domain.Abstractions.FacadeServices;
using CodeSmells.Domain.Abstractions.Services;
using CodeSmells.Domain.Entities;

namespace CodeSmells.FacadeServices
{
    /// <summary>
    /// Фасадный сервис, делегирующий работу <see cref="IBillingSystem"/>.
    /// </summary>
    public class AccountNotifier : INotificationService
    {
        private readonly IBillingSystem _billingSystem;


        public AccountNotifier(IBillingSystem billingSystem)
        {
            ArgumentNullException.ThrowIfNull(billingSystem, nameof(billingSystem));

            _billingSystem = billingSystem;
        }


        public void OrderApprove(Order order)
        {
            this._billingSystem.NotifyAccounting();
        }
    }
}
