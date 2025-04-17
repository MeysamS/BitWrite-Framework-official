using System.Net;
using BitWrite.Core.Exceptions.Base;

namespace BitWrite.Core.Exceptions.Http;

public class ApiException : BaseException
{
    public ApiException(string message, HttpStatusCode statusCode = HttpStatusCode.InternalServerError)
        : base(message)
    {
        StatusCode = statusCode;
    }
}
