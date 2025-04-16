using BitWrite.Abstraction.Domain.Event.Base;
using BitWrite.Abstraction.Events;

namespace BitWrite.Abstraction.Domain.Event.Notification;

public interface IDomainNotificationEvent : IEvent
{
}

public interface IDomainNotificationEvent<TDomainEventType> : IDomainNotificationEvent
    where TDomainEventType : IDomainEvent
{
    TDomainEventType DomainEvent { get; set; }
}