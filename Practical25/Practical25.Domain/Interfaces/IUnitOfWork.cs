namespace Practical25.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IEmployeeWriteRepository EmployeeWriteRepository { get; }
    IDepartmentWriteRepository DepartmentWriteRepository { get; }
    Task<int> SaveChangesAsync();
}
