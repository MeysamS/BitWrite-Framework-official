using System.Collections.Concurrent;
using System.Collections.Immutable;
using BitWrite.Abstraction.Domain.Aggregate;
using BitWrite.Abstraction.Domain.Event.Base;
using BitWrite.Abstraction.Domain.Rules;
using BitWrite.Core.Exceptions.DomainException;

namespace BitWrite.Core.Domain;

/// <summary>
/// Base class for all aggregate roots in the domain.
/// An aggregate root is the entry point to an aggregate, which is a cluster of domain objects that can be treated as a single unit.
/// </summary>
/// <typeparam name="TId">Type of the aggregate identifier</typeparam>
public abstract class AggregateRoot<TId> : Entity<TId>, IAggregate<TId>
    where TId : notnull
{
    [NonSerialized]
    private readonly ConcurrentQueue<IDomainEvent> _uncommittedDomainEvents = new();

    private const long NewAggregateVersion = 0;
    
    /// <summary>
    /// Gets the original version of the aggregate, used for optimistic concurrency
    /// </summary>
    public long OriginalVersion { get; protected set; } = NewAggregateVersion;

    /// <summary>
    /// Initializes a new instance of the AggregateRoot class with the specified ID
    /// </summary>
    /// <param name="id">The aggregate's unique identifier</param>
    protected AggregateRoot(TId id) 
    {
    }

    /// <summary>
    /// Protected constructor for ORM
    /// </summary>
    protected AggregateRoot() { }

    #region Domain Events

    /// <summary>
    /// Add the <paramref name="domainEvent"/> to the aggregate pending changes event.
    /// </summary>
    /// <param name="domainEvent">The domain event.</param>
    protected void AddDomainEvent(IDomainEvent domainEvent)
    {
        if (!_uncommittedDomainEvents.Any(x => Equals(x.EventId, domainEvent.EventId)))
        {
            _uncommittedDomainEvents.Enqueue(domainEvent);
        }
    }
    
    /// <summary>
    /// Applies a domain event to the aggregate and adds it to uncommitted events
    /// </summary>
    /// <typeparam name="TEvent">Type of the domain event</typeparam>
    /// <param name="domainEvent">The domain event to apply</param>
    protected void ApplyDomainEvent<TEvent>(TEvent domainEvent) 
        where TEvent : IDomainEvent
    {
        // Optional: Handle the event specifically if needed
        // HandleEvent(domainEvent);
        
        AddDomainEvent(domainEvent);
    }

    /// <summary>
    /// Gets the list of uncommitted domain events
    /// </summary>
    /// <returns>List of uncommitted domain events</returns>
    public IReadOnlyList<IDomainEvent> GetUncommittedDomainEvents()
    {
        return _uncommittedDomainEvents.ToImmutableList();
    }
    
    /// <summary>
    /// Dequeues all uncommitted domain events and returns them
    /// </summary>
    /// <returns>List of dequeued domain events</returns>
    public IReadOnlyList<IDomainEvent> DequeueUncommittedDomainEvents()
    {
        var events = _uncommittedDomainEvents.ToImmutableList();
        MarkUncommittedDomainEventAsCommitted();
        return events;
    }

    /// <summary>
    /// Checks if there are any uncommitted domain events
    /// </summary>
    /// <returns>True if there are uncommitted events, false otherwise</returns>
    public bool HasUncommittedDomainEvents()
    {
        return _uncommittedDomainEvents.Any();
    }

    /// <summary>
    /// Marks all uncommitted domain events as committed by removing them from the queue
    /// </summary>
    public void MarkUncommittedDomainEventAsCommitted()
    {
        _uncommittedDomainEvents.Clear();
        IncrementVersion();
    }

    /// <summary>
    /// Clears all domain events without incrementing the version
    /// </summary>
    public void ClearDomainEvents()
    {
        _uncommittedDomainEvents.Clear();
    }
    
    /// <summary>
    /// Increments the aggregate version
    /// </summary>
    protected void IncrementVersion()
    {
        OriginalVersion++;
    }

    #endregion

    #region Business Rules

    /// <summary>
    /// Checks if a business rule is satisfied, and throws an exception if it's broken
    /// </summary>
    /// <param name="rule">The business rule to check</param>
    /// <exception cref="BusinessRuleValidationException">Thrown when the rule is broken</exception>
    public void CheckRule(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    #endregion
}