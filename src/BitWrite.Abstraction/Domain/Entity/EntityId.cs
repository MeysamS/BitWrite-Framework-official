using BitWrite.Abstraction.Domain.Identity;

namespace BitWrite.Abstraction.Domain.Entity;

public record EntityId<T> : Identity<T>
{
    public static EntityId<T> CreateEntityId(T id) => new() { Value = id };
}

public record EntityId : EntityId<long>
{
    public static new EntityId CreateEntityId(long id) => new() { Value = id };
}