namespace Practical26.BAL.Queries.Employees;

public class GetAllEmployeesQuery
{
    public string? Id { get; set; } = null;
    public bool IsActive { get; set; } = true;
    public int Page { get; set; } = 1;
    public int Limit { get; set; } = 10;
}
