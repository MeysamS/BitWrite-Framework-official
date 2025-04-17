using System.Net;
using BitWrite.Core.Exceptions.Base;

namespace BitWrite.Core.Exceptions.Data;

public class DataIntegrityException : BaseException
{
    public DataIntegrityException(string message)
        : base(message, HttpStatusCode.UnprocessableEntity)
    {
    }
}