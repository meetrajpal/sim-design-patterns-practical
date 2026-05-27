namespace Practical26.DAL.Repositories.Base;

public class BaseReadRepository<T>(ApplicationDbContext context) : IBaseReadRepository<T> where T : BaseEntity
{
    protected readonly ApplicationDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public virtual async Task<ApiResponse<List<T>>> GetAllAsync(Guid? id, bool isActive = true, int page = 1, int limit = 10)
    {
        IQueryable<T> query = _dbSet;

        query = query.Where(x => x.IsActive == isActive);

        if (id != null)
            query = query.Where(x => x.Id == id);

        query = query.Skip((page - 1) * limit).Take(limit);

        var data = await query.AsNoTracking().ToListAsync();


        return ApiResponse<List<T>>.Success(data);
    }

}