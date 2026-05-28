namespace Practical25.BAL.Commands.Departments;

public class DeleteDepartmentCommand : IRequest<ApiResponse<string>>
{
    public string Id { get; set; } = string.Empty!;
}
