namespace Practical26.DAL.Repositories.Departments;

public class DepartmentReadRepository(ApplicationDbContext dbContext) : BaseReadRepository<Department>(dbContext), IDepartmentReadRepository
{

}
