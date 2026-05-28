namespace Practical25.Domain.Interfaces.Repositories.Departments;

public interface IDepartmentWriteRepository : IBaseWriteRepository<Department>
{
    Task<bool> GetByNameAsync(string name, CancellationToken cancellationToken);
}
