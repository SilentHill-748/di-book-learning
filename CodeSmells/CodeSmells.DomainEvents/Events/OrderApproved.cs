namespace CodeSmells.DomainEvents.Events
{
    /// <summary>
    /// Событий утверждения заказа.
    /// </summary>
    public class OrderApproved
    {
        public OrderApproved(Guid id)
        {
            Id = id;
        }


        public Guid Id { get; set; }
    }
}
