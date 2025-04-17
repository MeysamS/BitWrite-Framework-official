using BitWrite.Core.Exceptions.Http;

namespace BitWrite.Core.Exceptions.Application;

public class UnsupportedOperationException : BadRequestException
{
    public UnsupportedOperationException(string operation)
        : base($"Operation '{operation}' is not supported.")
    {
    }
}
