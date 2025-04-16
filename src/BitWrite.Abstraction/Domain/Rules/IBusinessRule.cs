namespace BitWrite.Abstraction.Domain.Rules;

/// <summary>
/// Represents a business rule.
/// </summary>
public interface IBusinessRule
{
    /// <summary>
    /// Checks if the rule is broken.
    /// </summary>
    /// <returns></returns>
    bool IsBroken();
    /// <summary>
    /// Gets the message associated with the rule.
    /// </summary>
    string Message { get; }
}