using CodeSmells.Domain.Abstractions.EventHandlers;

namespace CodeSmells.DomainEvents.EventHandlers
{
    /// <summary>
    /// Компоновщик обработчиков событий для указанного типа события. Имплементирует <see cref="IEventHandler{TEvent}"/>.
    /// </summary>
    /// <typeparam name="TEvent">Доменное событие</typeparam>
    public class CompositeEventHandler<TEvent> : IEventHandler<TEvent>
    {
        private readonly IEnumerable<IEventHandler<TEvent>> _handlers;


        public CompositeEventHandler(IEnumerable<IEventHandler<TEvent>> handlers)
        {
            ArgumentNullException.ThrowIfNull(handlers, nameof(handlers));

            _handlers = handlers;
        }


        public void Handle(TEvent e)
        {
            foreach (IEventHandler<TEvent> handler in _handlers)
            {
                handler.Handle(e);
            }
        }
    }
}
