using BitWrite.Abstraction.Domain.Event.Base;

namespace BitWrite.Abstraction.Domain.Event.Publishing;

public interface IDomainEventPublisher
{
    Task PublishAsync(IDomainEvent domainEvent, CancellationToken cancellationToken = default);
    Task PublishAsync(IDomainEvent[] domainEvents, CancellationToken cancellationToken = default);
}