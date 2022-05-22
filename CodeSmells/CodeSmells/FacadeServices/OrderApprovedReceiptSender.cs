using CodeSmells.Domain.Abstractions.FacadeServices;
using CodeSmells.Domain.Abstractions.Services;
using CodeSmells.Domain.Entities;

namespace CodeSmells.FacadeServices
{
    /// <summary>
    /// Фасадный сервис, делигирующий работу <see cref="IMessageService"/>.
    /// </summary>
    public class OrderApprovedReceiptSender : INotificationService
    {
        private readonly IMessageService _messageService;


        public OrderApprovedReceiptSender(IMessageService messageService)
        {
            ArgumentNullException.ThrowIfNull(messageService, nameof(messageService));

            _messageService = messageService;
        }


        public void OrderApprove(Order order)
        {
            this._messageService.SendReceipt();
        }
    }
}
