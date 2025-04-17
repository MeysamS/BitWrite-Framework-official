using BitWrite.Core.Exceptions.Http;

namespace BitWrite.Core.Exceptions.Data;

public class DuplicateRecordException : ConflictException
{
    public DuplicateRecordException(string entityName, string identifier)
        : base($"{entityName} with identifier '{identifier}' already exists.")
    {
    }
}
