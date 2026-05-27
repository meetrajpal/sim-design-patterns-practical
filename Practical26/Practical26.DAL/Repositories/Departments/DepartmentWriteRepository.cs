namespace Practical26.DAL.Repositories.Departments;

public class DepartmentWriteRepository(ApplicationDbContext dbContext) : BaseWriteRepository<Department>(dbContext), IDepartmentWriteRepository
{
    public async Task<bool> GetByNameAsync(string name)
    {
        return await _dbSet.AnyAsync(x => x.DepartmentName == name);
    }
}
