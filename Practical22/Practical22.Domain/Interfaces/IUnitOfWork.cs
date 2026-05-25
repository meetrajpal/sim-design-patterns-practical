using Practical22.Domain.Interfaces.Repositories;

namespace Practical22.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository EmployeeRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
    Task<int> SaveChangesAsync();
}
