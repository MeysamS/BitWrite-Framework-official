using System.Net;
using BitWrite.Core.Exceptions.Base;

namespace BitWrite.Core.Exceptions.Http;

public class ConflictException : BaseException
{
    public ConflictException(string message)
        : base(message)
    {
        StatusCode = HttpStatusCode.Conflict;
    }
}

