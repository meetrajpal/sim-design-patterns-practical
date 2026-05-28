namespace Practical25.BAL.Commands.Departments;

public class CreateDepartmentCommand : DepartmentCreateRequestDTO, IRequest<ApiResponse<Department>>
{
}
