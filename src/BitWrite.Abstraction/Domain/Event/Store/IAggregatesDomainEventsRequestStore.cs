using BitWrite.Abstraction.Domain.Aggregate;
using BitWrite.Abstraction.Domain.Event.Base;

namespace Bw.Abstraction.Domain.Event;

public interface IAggregatesDomainEventsRequestStore
{
    IReadOnlyList<IDomainEvent> AddEventsFromAggregate<T>(T aggregate)
      where T : IHaveAggregate;

    void AddEvents(IReadOnlyList<IDomainEvent> events);

    IReadOnlyList<IDomainEvent> GetAllUncommittedEvents();
}