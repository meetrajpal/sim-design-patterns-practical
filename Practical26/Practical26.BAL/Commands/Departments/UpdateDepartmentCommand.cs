namespace Practical26.BAL.Commands.Departments;

public class UpdateDepartmentCommand : DepartmentUpdateRequestDTO
{
    public string Id { get; set; } = string.Empty!;
}
