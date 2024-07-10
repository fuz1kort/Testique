namespace Testique.API.Domain.Common.Interfaces;

public interface IAuditableEntity : IEntity
{
    string CreatedBy { get; set; }
    DateTime? CreatedDate { get; set; }
    Guid? UpdatedBy { get; set; }
    DateTime? UpdatedDate { get; set; }
}