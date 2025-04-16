using BitWrite.Abstraction.Domain.Entity;
using BitWrite.Abstraction.Domain.Identity;

namespace BitWrite.Abstraction.Domain.Aggregate;

public interface IAggregate<out TId> : IEntity<TId>, IHaveAggregate
{
}


public interface IAggregate<out TIdentity, TId> : IAggregate<TIdentity>
    where TIdentity : Identity<TId>
{ }

public interface IAggregate : IAggregate<AggregateId, long> { }
