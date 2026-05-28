namespace Practical25.BAL.Commands.Departments;

public class UpdateDepartmentCommand : DepartmentUpdateRequestDTO, IRequest<ApiResponse<string>>
{
    public string Id { get; set; } = string.Empty!;
}
