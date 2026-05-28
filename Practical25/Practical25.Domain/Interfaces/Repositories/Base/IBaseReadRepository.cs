namespace Practical25.Domain.Interfaces.Repositories.Base;

public interface IBaseReadRepository<T> where T : BaseEntity
{
    Task<ApiResponse<List<T>>> GetAllAsync(Guid? id, bool isActive, int page, int limit, CancellationToken cancellationToken = default);
}