using Testique.API.Domain.Common.Interfaces;

namespace Testique.API.Domain.Common;

public class BaseEntity : IEntity
{
    /// <inheritdoc />
    public Guid Id { get; set; }
}