namespace BitWrite.Abstraction.Events.Handling;

public interface IIntegrationEventHandler<in TEvent> : IEventHandler<TEvent>
    where TEvent : IIntegrationEvent
{ }