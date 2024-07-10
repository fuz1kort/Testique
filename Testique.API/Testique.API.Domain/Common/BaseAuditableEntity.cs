using Testique.API.Domain.Common.Interfaces;

namespace Testique.API.Domain.Common;

public class BaseAuditableEntity : BaseEntity, IAuditableEntity
{
    /// <inheritdoc />
    public string? CreatedBy { get; set; }

    /// <inheritdoc />
    public DateTime? CreatedDate { get; set; }

    /// <inheritdoc />
    public Guid? UpdatedBy { get; set; }

    /// <inheritdoc />
    public DateTime? UpdatedDate { get; set; }
}