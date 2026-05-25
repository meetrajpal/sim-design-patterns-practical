using Practical22.Domain.Entities;

namespace Practical22.Domain.Interfaces.Repositories;

public interface IDepartmentRepository : IBaseRepository<Department>
{
    Task<bool> GetByNameAsync(string name);
}
