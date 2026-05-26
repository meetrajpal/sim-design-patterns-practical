using Practical23.Domain.Interfaces.Repositories;

namespace Practical23.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IEmployeeRepository EmployeeRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
    Task<int> SaveChangesAsync();
}
