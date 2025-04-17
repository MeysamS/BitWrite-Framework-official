using BitWrite.Core.Exceptions.Http;

namespace BitWrite.Core.Exceptions.Validation;

public class InvalidCurrencyException : BadRequestException
{
    public string Currency { get; }

    public InvalidCurrencyException(string currency)
        : base($"Currency: '{currency}' is invalid.")
    {
        Currency = currency;
    }
}