using BitWrite.Abstraction.Events;

namespace BitWrite.Abstraction.Messaging;
/// <summary>
/// Represents the base contract for all messages in the system
/// </summary>

public interface IMessage : IEvent
{
    Guid MessageId { get; }
    DateTime Created { get; }
}