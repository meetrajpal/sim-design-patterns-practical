namespace Practical25.DAL.Repositories.Employees;

public class EmployeeWriteRepository(ApplicationDbContext dbContext) : BaseWriteRepository<Employee>(dbContext), IEmployeeWriteRepository
{
    public override async Task<Employee?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbSet.Include("Department").FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }
}
