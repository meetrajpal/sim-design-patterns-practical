namespace Practical24.DAL.Repositories;

public class DepartmentRepository(ApplicationDbContext dbContext) : BaseRepository<Department>(dbContext), IDepartmentRepository
{
    public async Task<bool> GetByNameAsync(string name)
    {
        return await _dbSet.AnyAsync(x => x.DepartmentName == name);
    }
}
