namespace BitWrite.Abstraction.Domain.Auditable;


public interface IHaveAudit : IHaveCreator
{
    DateTime? UpdatedDate { get; }
    int? UpdatorId { get; }
}
