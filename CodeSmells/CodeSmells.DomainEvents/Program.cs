using CodeSmells.Domain.Entities;
using CodeSmells.Domain.Abstractions.Services;
using CodeSmells.DomainEvents;
using CodeSmells.DomainEvents.Events;

Console.WriteLine("Hello, World!");
Console.WriteLine("Задача проекта - решить проблему чрезмерного внедрения через констуруктор, используя доменные события.");
Console.WriteLine();

IOrderService orderApprovedService = GetOrderService<OrderApproved>();
IOrderService orderCancelledService = GetOrderService<OrderCancelled>();

Console.WriteLine("Run approved order service:");
orderApprovedService.OrderApprove(new Order());

Console.WriteLine();

Console.WriteLine("Run cancelled order service:");
orderCancelledService.OrderApprove(new Order());



// Играет роль корня композиции.
static IOrderService CompositionRoot<TEvent>()
{
    // Для примера определил все виды хендлеров.
    if (typeof(TEvent).Equals(typeof(OrderApproved)))
        return OrderServiceHelper.GetApprovedOrderService();

    return OrderServiceHelper.GetCancelledOrderService();
}

static IOrderService GetOrderService<TEvent>()
{
    return CompositionRoot<TEvent>();
}