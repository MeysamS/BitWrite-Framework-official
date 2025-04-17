using System.Net;

namespace BitWrite.Core.Exceptions.Identity;

public class UnauthorizedException : IdentityException
{
    public UnauthorizedException(string message)
        : base(message, HttpStatusCode.Unauthorized) { }
}
