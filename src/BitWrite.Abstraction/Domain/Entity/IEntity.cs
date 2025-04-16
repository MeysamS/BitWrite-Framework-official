using BitWrite.Abstraction.Domain.Auditable;
using BitWrite.Abstraction.Domain.Identity;

namespace BitWrite.Abstraction.Domain.Entity;

public interface IEntity<out TId> : IHaveIdentity<TId>, IHaveCreator { }


public interface IEntity<out TIdentity, in TId> : IEntity<TIdentity>
    where TIdentity : IIdentity<TId>
{ }

public interface IEntity : IEntity<EntityId> { }
