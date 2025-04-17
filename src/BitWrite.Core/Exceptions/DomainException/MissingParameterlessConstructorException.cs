namespace BitWrite.Core.Exceptions.DomainException;

// Define the specific exception (e.g., in Core/Exceptions)
public class MissingParameterlessConstructorException : InvalidOperationException
{
    public MissingParameterlessConstructorException(Type aggregateType)
        : base($"Aggregate type '{aggregateType.Name}' requires an accessible parameterless constructor for the factory.")
    { }
}
