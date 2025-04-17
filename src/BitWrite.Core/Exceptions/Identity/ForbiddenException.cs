using System.Net;

namespace BitWrite.Core.Exceptions.Identity;

public class ForbiddenException : IdentityException
{
    public ForbiddenException(string message)
        : base(message, statusCode: HttpStatusCode.Forbidden) { }
}
