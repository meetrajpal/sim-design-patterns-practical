namespace Practical26.BAL.Commands.Employees;

public class UpdateEmployeeCommand : EmployeeUpdateRequestDTO
{
    public string Id { get; set; } = string.Empty!;
}
