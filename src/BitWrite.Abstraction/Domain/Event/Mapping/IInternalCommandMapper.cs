using BitWrite.Abstraction.Commands;
using BitWrite.Abstraction.Domain.Event.Base;

namespace BitWrite.Abstraction.Domain.Event.Mapping;

public interface IInternalCommandMapper
{
    IReadOnlyList<IInternalCommand?>? MapToInternalCommands(IReadOnlyList<IDomainEvent> domainEvents);
    IInternalCommand? MapToInternalCommand(IDomainEvent domainEvent);
}
