using System.Net;
using BitWrite.Core.Exceptions.Base;

namespace BitWrite.Core.Exceptions.Application;

public class AppException : BaseException
{
    public AppException(string message, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        : base(message)
    {
        StatusCode = statusCode;
    }
}


