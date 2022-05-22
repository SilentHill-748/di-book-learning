using CodeSmells.Domain.Abstractions.Services;
using CodeSmells.Domain.Abstractions.EventHandlers;
using CodeSmells.DomainEvents.Events;

namespace CodeSmells.DomainEvents.EventHandlers
{
    /// <summary>
    /// Обработчик события утверждения заказа, отправляющий письмо на почту пользователя через <see cref="IMessageService"/>.
    /// Является аналогом фасадному сервису CodeSmells.FacadeServices.OrderApprovedReceiptSender
    /// </summary>
    public class OrderApprovedReceiptSender : IEventHandler<OrderApproved>
    {
        private readonly IMessageService _messageService;


        public OrderApprovedReceiptSender(IMessageService messageService)
        {
            ArgumentNullException.ThrowIfNull(messageService, nameof(messageService));

            this._messageService = messageService;
        }


        public void Handle(OrderApproved e)
        {
            this._messageService.SendReceipt();
        }
    }
}
