namespace Practical23.Domain.DTOs.Department;

public class DepartmentUpdateRequestDTO
{
    public string DepartmentName { get; set; } = string.Empty!;
    public bool IsActive { get; set; }
}
