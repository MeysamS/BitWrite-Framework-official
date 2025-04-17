using System.Net;
using BitWrite.Core.Exceptions.Base;

namespace BitWrite.Core.Exceptions.Http;

public class BadRequestException :BaseException
{
    public BadRequestException(string message)
        : base(message)
    {
        StatusCode = HttpStatusCode.BadRequest;
    }
}
