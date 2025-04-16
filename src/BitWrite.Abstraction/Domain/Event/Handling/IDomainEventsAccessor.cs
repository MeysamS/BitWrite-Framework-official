using BitWrite.Abstraction.Domain.Event.Base;

namespace BitWrite.Abstraction.Domain.Event.Handling;

public interface IDomainEventsAccessor
{
    IReadOnlyList<IDomainEvent> UnCommittedDomainEvents { get; }
}