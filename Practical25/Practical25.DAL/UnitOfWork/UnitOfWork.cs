namespace Practical25.DAL.UnitOfWork;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;

    private readonly Lazy<IDepartmentWriteRepository> _departmentWriteRepository = new(() => new DepartmentWriteRepository(context));

    private readonly Lazy<IEmployeeWriteRepository> _employeeWriteRepository = new(() => new EmployeeWriteRepository(context));

    public IDepartmentWriteRepository DepartmentWriteRepository => _departmentWriteRepository.Value;

    public IEmployeeWriteRepository EmployeeWriteRepository => _employeeWriteRepository.Value;


    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }
}
