namespace Practical25.BAL.Commands.Employees;

public class DeleteEmployeeCommand : IRequest<ApiResponse<string>>
{
    public string Id { get; set; } = string.Empty!;
}
