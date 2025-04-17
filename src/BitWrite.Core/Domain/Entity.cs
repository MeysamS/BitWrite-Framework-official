using BitWrite.Abstraction.Domain.Entity;
using BitWrite.Abstraction.Domain.Identity;

namespace BitWrite.Core.Domain;

public abstract class Entity<TId> : IEntity<TId>
    where TId : notnull
{
    public TId Id { get; protected set; } = default!;

    public DateTime CreatedDate { get; private set; } = default!;

    public int? CreatorId { get; private set; } = default!;
}


public abstract class Entity<TIdentity, TId> : Entity<TIdentity>
    where TIdentity : Identity<TId>
{ }

public abstract class Entity : Entity<EntityId, long>, IEntity { }