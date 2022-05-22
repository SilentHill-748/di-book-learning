using CodeSmells.Domain.Entities;

namespace CodeSmells.Domain.Abstractions.Services
{
    public interface IOrderService
    {
        void OrderApprove(Order order);
        void UpdateOrder(Order order);

        // Эти методы были убраны в ходе рефакторинга кода сервиса.
        // Но изменение абстракции как правило влечёт за собой изменения в реализации.
        //void Notify(Order order);
        //void Fulfill(Order order);
    }
}
