namespace BitWrite.Abstraction.Domain.Identity;

public interface IIdentity<out TId>
{
    public TId Value { get; }
}
