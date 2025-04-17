using System.Net;
using BitWrite.Core.Exceptions.Base;

namespace BitWrite.Core.Exceptions.Http;

/// <summary>
/// Exception thrown when a requested resource is not found.
/// </summary>
public class NotFoundException : BaseException
{
    /// <summary>
    /// Initializes a new instance of the NotFoundException class.
    /// </summary>
    /// <param name="message">The error message</param>
    public NotFoundException(string message)
        : base(message, HttpStatusCode.NotFound)
    {
    }

    /// <summary>
    /// Initializes a new instance of the NotFoundException class with additional error details.
    /// </summary>
    /// <param name="message">The error message</param>
    /// <param name="errors">Additional error details</param>
    public NotFoundException(string message, params string[] errors)
        : base(message, HttpStatusCode.NotFound, errors)
    {
    }
}

