namespace BitWrite.Core.Exceptions.Application;

public class ExecutionFailedException : AppException
{
    public string OperationName { get; }
    
    public ExecutionFailedException(string operationName, string message)
        : base($"Operation '{operationName}' failed: {message}")
    {
        OperationName = operationName;
    }
}