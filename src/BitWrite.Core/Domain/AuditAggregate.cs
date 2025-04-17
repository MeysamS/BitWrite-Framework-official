using BitWrite.Abstraction.Domain.Auditable;
using BitWrite.Abstraction.Domain.Identity;

namespace BitWrite.Core.Domain;

public abstract class AuditAggregate<TId> : AggregateRoot<TId>, IAuditableEntity<TId>
    where TId : notnull
{

    public DateTime? UpdatedDate { get; protected set; } = default!;

    public int? UpdatorId { get; protected set; } = default!;

}


public abstract class AuditAggregate<TIdentity, TId> : AuditAggregate<TIdentity>
    where TIdentity : Identity<TId>
{
}

public abstract class AuditAggregate : AuditAggregate<Identity<long>, long>
{
}

