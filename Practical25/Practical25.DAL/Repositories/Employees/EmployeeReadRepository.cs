namespace Practical25.DAL.Repositories.Employees;

public class EmployeeReadRepository(ApplicationDbContext dbContext) : BaseReadRepository<Employee>(dbContext), IEmployeeReadRepository
{
    public override async Task<ApiResponse<List<Employee>>> GetAllAsync(Guid? id, bool isActive = true, int page = 1, int limit = 10, CancellationToken cancellationToken = default)
    {
        IQueryable<Employee> query = _dbSet;

        query = query.Where(x => x.IsActive == isActive);

        if (id != null)
            query = query.Where(x => x.Id == id);

        query = query.Skip((page - 1) * limit).Take(limit);

        var data = await query.Include("Department").ToListAsync(cancellationToken);


        return ApiResponse<List<Employee>>.Success(data);
    }

}
