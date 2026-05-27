using Practical24.Domain.Interfaces.Repositories;

namespace Practical24.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository EmployeeRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
    Task<int> SaveChangesAsync();
}
