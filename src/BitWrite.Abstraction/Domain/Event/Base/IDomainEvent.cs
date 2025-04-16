using BitWrite.Abstraction.Events;

namespace BitWrite.Abstraction.Domain.Event.Base;

/// <summary>
/// The domain event interface.
/// </summary>
public interface IDomainEvent : IEvent
{
    /// <summary>
    /// Gets the identifier of the aggregate which has generated the event.
    /// </summary>

    dynamic AggregateId { get; }
    long AggregateSequenceNumber { get; }

    public IDomainEvent WithAggregate(dynamic aggregateId, long version);
}