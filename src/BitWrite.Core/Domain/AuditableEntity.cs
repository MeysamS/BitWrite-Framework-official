using BitWrite.Abstraction.Domain.Auditable;
using BitWrite.Abstraction.Domain.Identity;

namespace BitWrite.Core.Domain;

public class AuditableEntity<TId> : Entity<TId>, IAuditableEntity<TId>
    where TId : notnull
{

    public DateTime? UpdatedDate { get; protected set; }

    public int? UpdatorId { get; protected set; }

}

public abstract class AuditableEntity<TIdentity, TId> : AuditableEntity<TIdentity>
where TIdentity : Identity<TId>
{
}

public class AuditableEntity : AuditableEntity<Identity<long>, long>
{
}
