namespace Practical25.BAL.Queries.Employees;

public class GetAllEmployeesQuery : IRequest<ApiResponse<List<Employee>>>
{
    public string? Id { get; set; } = null;
    public bool IsActive { get; set; } = true;
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 10;
}
