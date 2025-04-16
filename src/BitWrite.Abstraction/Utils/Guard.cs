namespace BitWrite.Abstraction.Utils;

public static class Guard
{
    public static class Against
    {
        public static T NegativeOrZero<T>(T value, string? parameterName = null)
            where T : IComparable<T>
        {
            if (value.CompareTo(default) <= 0)
            {
                throw new ArgumentException($"Value cannot be negative or zero.", parameterName);

            }
            return value;

        }
    }

    public static T Null<T>(T? value, string? parameterName = null)
           where T : class
    {
        if (value is null)
        {
            throw new ArgumentNullException(parameterName);
        }

        return value;
    }

    public static string NullOrEmpty(string? value, string? parameterName = null)
    {
        if (string.IsNullOrEmpty(value))
        {
            throw new ArgumentException("Value cannot be null or empty.", parameterName);
        }

        return value;
    }
}