using CodeSmells;
using CodeSmells.FacadeServices;
using CodeSmells.DataAccessLayer;
using CodeSmells.Domain.Implementations.Services;
using CodeSmells.Domain.Abstractions.FacadeServices;
using CodeSmells.Domain.Abstractions.Services;
using CodeSmells.Domain.Entities;

Console.WriteLine("Hello, World!");
Console.WriteLine("Задача проекта показать, что такое чрезмерное внедрение через конструктор\nи показать способ его решения, используя фасадные сервисы.");
Console.WriteLine();

IOrderService overInjectedOrderService = GetOrderService();
IOrderService normalOrderService = GetOrderService(false);

Console.WriteLine("Over injected service is called:");
overInjectedOrderService.OrderApprove(new Order());

Console.WriteLine();

Console.WriteLine("Normal injected service is called:");
normalOrderService.OrderApprove(new Order());

// Этот метод играет роль проекта - корня композиции всех зависимостей.
static IOrderService CompositionRoot()
{
    INotificationService[] notificationServices = new INotificationService[]
    {
        new OrderApprovedReceiptSender(new MessageService()),
        new AccountNotifier(new BillingSystem()),
        new OrderFulfillService(new LocationService(), new InventoryManagment())
    };

    CompositeNotificationService compositeService = new(notificationServices);

    OrderRepository orderRepository = new();

    return new NormalOrderService(orderRepository, compositeService);

    //return new NormalOrderService(
    //    new OrderRepository(),
    //    new CompositeNotificationService(
    //        new INotificationService[]
    //        {
    //            new OrderApprovedReceiptSender(new MessageService()),
    //            new AccountNotifier(new BillingSystem()),
    //            new OrderFulfillService(new LocationService(), new InventoryManagment())
    //        }));
}

// Вспомогательный метод вывода сервиса IOrderService.
static IOrderService GetOrderService(bool isOverInjected = true)
{
    // Если флаг не менялся, возвращается перегруженный зависимостями сервис.
    return isOverInjected ?
        new OrderServiceOverInjection(
            new OrderRepository(),
            new MessageService(),
            new LocationService(),
            new BillingSystem(),
            new InventoryManagment()) :
        CompositionRoot();
}
