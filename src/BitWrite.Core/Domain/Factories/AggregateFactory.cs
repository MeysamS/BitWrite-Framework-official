using System.Linq.Expressions;
using System.Reflection;
using BitWrite.Core.Exceptions.DomainException;

namespace BitWrite.Core.Domain.Factories;

/// <summary>
/// Provides optimized creation of aggregate instances using their parameterless constructor.
/// Primarily used for scenarios like Event Sourcing reconstitution.
/// </summary>
/// <typeparam name="T">The type of the aggregate, must have a parameterless constructor.</typeparam>
public static class AggregateFactory<T>
{
    // Cached compiled constructor delegate for performance
    private static readonly Func<T>? _constructor = CreateTypeConstructor();

    /// <summary>
    /// Creates and compiles a delegate for the parameterless constructor of type T.
    /// </summary>
    private static Func<T>? CreateTypeConstructor()
    {
        try
        {
            // Ensure T has a parameterless constructor
            var constructorInfo = typeof(T).GetConstructor(Type.EmptyTypes);
            if (constructorInfo == null)
            {
                 // Check protected/private constructors too if needed for ES
                 constructorInfo = typeof(T).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Type.EmptyTypes, null);
                 if (constructorInfo == null) return null; // No parameterless constructor found
            }

            // Create expression: () => new T()
            var newExpr = Expression.New(constructorInfo);
            var lambda = Expression.Lambda<Func<T>>(newExpr);
            return lambda.Compile();
        }
        catch (Exception ex) // Catch broader exceptions during expression compilation
        {
            // Log the error maybe?
            Console.Error.WriteLine($"Error creating constructor delegate for {typeof(T).Name}: {ex.Message}");
            return null;
        }
    }

    /// <summary>
    /// Creates a new instance of the aggregate T using its parameterless constructor.
    /// </summary>
    /// <returns>A new instance of T.</returns>
    /// <exception cref="MissingParameterlessConstructorException">Thrown if type T does not have an accessible parameterless constructor.</exception>
    public static T CreateAggregate()
    {
        if (_constructor == null)
            throw new MissingParameterlessConstructorException(typeof(T)); // Use specific exception

        try
        {
            return _constructor();
        }
        catch (Exception ex)
        {
            // Handle potential exceptions during actual construction if needed
            throw new InvalidOperationException($"Failed to construct aggregate '{typeof(T).Name}'. See inner exception.", ex);
        }
    }
}
