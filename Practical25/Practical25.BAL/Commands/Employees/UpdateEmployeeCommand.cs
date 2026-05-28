namespace Practical25.BAL.Commands.Employees;

public class UpdateEmployeeCommand : EmployeeUpdateRequestDTO, IRequest<ApiResponse<string>>
{
    public string Id { get; set; } = string.Empty!;
}
