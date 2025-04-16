using BitWrite.Abstraction.Events.Handling;

namespace BitWrite.Abstraction.Domain.Event.Notification;

public interface IDomainNotificationEventHandler<in TEvent> : IEventHandler<TEvent>
where TEvent : IDomainNotificationEvent
{ }