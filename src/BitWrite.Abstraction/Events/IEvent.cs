namespace BitWrite.Abstraction.Events;

/// <summary>
/// Represents the base contract for all events in the system
/// </summary>
public interface IEvent
{
 /// <summary>
    /// Gets the event identifier.
    /// </summary>
    Guid EventId { get; }

    /// <summary>
    /// Gets the event/aggregate root version.
    /// </summary>
    long EventVersion { get; }

    /// <summary>
    /// Gets the date the <see cref="IEvent"/> occurred on.
    /// </summary>
    DateTime OccurredOn { get; }

    DateTimeOffset TimeStamp { get; }

    /// <summary>
    /// Gets type of this event.
    /// </summary>
    public string EventType { get; }
} 