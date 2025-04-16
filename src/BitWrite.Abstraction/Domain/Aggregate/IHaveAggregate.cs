using BitWrite.Abstraction.Domain.Event.Base;

namespace BitWrite.Abstraction.Domain.Aggregate;

public interface IHaveAggregate : IHaveDomainEvents, IHaveAggregateVersion
{
}
