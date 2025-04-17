using System.Net;

namespace BitWrite.Core.Exceptions.Base;

/// <summary>
/// Base class for all custom exceptions in the system
/// </summary>
public abstract class BaseException : Exception
{
    /// <summary>
    /// Gets the collection of error messages
    /// </summary>
    public IReadOnlyCollection<string> ErrorMessages { get; protected set; }

    /// <summary>
    /// Gets the HTTP status code
    /// </summary>
    public HttpStatusCode StatusCode { get; protected set; }

    /// <summary>
    /// Initializes a new instance of the BaseException class
    /// </summary>
    /// <param name="message">The error message</param>
    /// <param name="statusCode">The HTTP status code</param>
    /// <param name="errors">Additional error messages</param>
    protected BaseException(
        string message,
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError,
        params string[] errors) : base(message)
    {
        ErrorMessages = errors ?? Array.Empty<string>();
        StatusCode = statusCode;
    }
}