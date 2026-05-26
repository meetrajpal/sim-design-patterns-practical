namespace Practical23.DAL.UnitOfWork;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    private readonly ApplicationDbContext _context = context;

    private readonly Lazy<IEmployeeRepository> _employeeRepository = new(() => new EmployeeRepository(context));

    private readonly Lazy<IDepartmentRepository> _departmentRepository = new(() => new DepartmentRepository(context));

    public IEmployeeRepository EmployeeRepository => _employeeRepository.Value;
    public IDepartmentRepository DepartmentRepository => _departmentRepository.Value;

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
