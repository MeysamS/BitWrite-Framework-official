using BitWrite.Abstraction.Domain.Event.Base;

namespace BitWrite.Abstraction.Domain.Event.Publishing;

public interface IDomainEventContext
{
    IReadOnlyList<IDomainEvent> GetAllUncommittedEvents();
    void MarkUncommittedDomainEventAsCommitted();
}