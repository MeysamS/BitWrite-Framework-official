namespace BitWrite.Abstraction.Domain.Auditable;

public interface IHaveCreator

{
    DateTime CreatedDate { get; }
    int? CreatorId { get; }
}