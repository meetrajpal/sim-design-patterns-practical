using Practical24.Domain.Entities;

namespace Practical24.Domain.Interfaces.Repositories;

public interface IDepartmentRepository : IBaseRepository<Department>
{
    Task<bool> GetByNameAsync(string name);
}
