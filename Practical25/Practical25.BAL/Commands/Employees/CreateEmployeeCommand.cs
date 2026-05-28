namespace Practical25.BAL.Commands.Employees;

public class CreateEmployeeCommand : EmployeeCreateRequestDTO, IRequest<ApiResponse<Employee>>
{
}
