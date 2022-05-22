namespace CodeSmells.DomainEvents.Events
{
    /// <summary>
    /// Событие отмены заказа.
    /// </summary>
    public class OrderCancelled
    {
        public OrderCancelled(Guid id)
        {
            Id = id;
        }


        public Guid Id { get; set; }
    }
}
