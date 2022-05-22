using CodeSmells.Domain.Abstractions.Services;
using CodeSmells.Domain.Abstractions.Repositories;
using CodeSmells.Domain.Entities;

namespace CodeSmells
{
    /// <summary>
    /// Сервис, в котором было выполнено чрезмерное внедрение зависимостей.
    /// </summary>
    public class OrderServiceOverInjection : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMessageService _messageService;
        private readonly IInventoryManagment _inventoryManagment;
        private readonly ILocationService _locationService;
        private readonly IBillingSystem _billingSystem;


        // У конструктор 5 зависимостей. Это первый запах того, что класс нарушает SRP.
        public OrderServiceOverInjection(
            IOrderRepository orderRepository,
            IMessageService messageService,
            ILocationService locationService,
            IBillingSystem billingSystem,
            IInventoryManagment inventoryManagment)
        {
            ArgumentNullException.ThrowIfNull(orderRepository, nameof(orderRepository));
            ArgumentNullException.ThrowIfNull(messageService, nameof(messageService));
            ArgumentNullException.ThrowIfNull(locationService, nameof(locationService));
            ArgumentNullException.ThrowIfNull(billingSystem, nameof(billingSystem));
            ArgumentNullException.ThrowIfNull(inventoryManagment, nameof(inventoryManagment));

            _orderRepository = orderRepository;
            _messageService = messageService;
            _locationService = locationService;
            _billingSystem = billingSystem;
            _inventoryManagment = inventoryManagment;
        }


        // Методов хоть и немного, это лишь пример.
        // На самом деле код методов может быть объемный.
        // Из-за этого, код класса может раздуться на 100+ строк.
        public void OrderApprove(Order order)
        {
            this.UpdateOrder(order);
            this.Notify(order);
        }

        public void UpdateOrder(Order order)
        {
            order.Approve();
            this._orderRepository.Save(order);
        }

        public void Notify(Order order)
        {
            this._messageService.SendReceipt();
            this._billingSystem.NotifyAccounting();
            this.Fulfill(order);
        }

        public void Fulfill(Order order)
        {
            this._locationService.FindWarehouses();
            this._inventoryManagment.NotifyWarehouses();
        }
    }
}
