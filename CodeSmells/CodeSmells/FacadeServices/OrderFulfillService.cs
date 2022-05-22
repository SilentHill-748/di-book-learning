using CodeSmells.Domain.Abstractions.FacadeServices;
using CodeSmells.Domain.Abstractions.Services;
using CodeSmells.Domain.Entities;

namespace CodeSmells.FacadeServices
{
    /// <summary>
    /// Фасадный сервис, делегирующий работу <see cref="ILocationService"/> и <see cref="IInventoryManagment"/>.
    /// </summary>
    public class OrderFulfillService : INotificationService
    {
        private readonly ILocationService _locationService;
        private readonly IInventoryManagment _inventoryManagment;


        public OrderFulfillService(ILocationService locationService, IInventoryManagment inventoryManagment)
        {
            ArgumentNullException.ThrowIfNull(locationService, nameof(locationService));
            ArgumentNullException.ThrowIfNull(inventoryManagment, nameof(inventoryManagment));

            _locationService = locationService;
            _inventoryManagment = inventoryManagment;
        }


        public void OrderApprove(Order order)
        {
            this._locationService.FindWarehouses();
            this._inventoryManagment.NotifyWarehouses();
        }
    }
}
