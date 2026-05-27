namespace Practical26.Domain.Entities.Interfaces;

public interface IAuditEnitity
{
    DateTime CreatedAt { get; set; }
    DateTime? UpdatedAt { get; set; }
}
