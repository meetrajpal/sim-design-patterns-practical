using Practical23.Domain.Entities;

namespace Practical23.Domain.Interfaces.Repositories;

public interface IDepartmentRepository : IBaseRepository<Department>
{
    Task<bool> GetByNameAsync(string name);
}
