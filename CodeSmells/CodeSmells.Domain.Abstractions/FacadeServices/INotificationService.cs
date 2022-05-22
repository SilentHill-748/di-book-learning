using CodeSmells.Domain.Entities;

namespace CodeSmells.Domain.Abstractions.FacadeServices
{
    /// <summary>
    /// Интерфейс фасадного сервиса.
    /// </summary>
    public interface INotificationService
    {
        // Решение неплохое, но проблема данных сервисов в том, что если будет много
        // близких по смыслу методов - это приведет к постоянному расширению интерфейса,
        // пока он не станет слишком большим и его не придётся разделять по ISP.

        // Хуже того, постоянные изменения в интерфейсе приведут к изменению всех его
        // реализаций.
        void OrderApprove(Order order);
    }
}
