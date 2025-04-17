using System.Net;
using BitWrite.Core.Exceptions.Base;

namespace BitWrite.Core.Exceptions.Identity;

public class IdentityException : BaseException
{
    public IdentityException(
        string message,
        HttpStatusCode statusCode = HttpStatusCode.BadRequest,
        params string[] errors
    )
        : base(message, statusCode, errors) { }
}
