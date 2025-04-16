using BitWrite.Abstraction.Domain.Event.Base;
using BitWrite.Abstraction.Events.Handling;

namespace BitWrite.Abstraction.Domain.Event.Handling;

public interface IDomainEventHandler<in TEvent> : IEventHandler<TEvent>
    where TEvent : IDomainEvent
{
}