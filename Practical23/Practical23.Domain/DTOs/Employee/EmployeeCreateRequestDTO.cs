namespace Practical23.Domain.DTOs.Employee;

public class EmployeeCreateRequestDTO
{
    public string EmployeeName { get; set; } = string.Empty!;
    public decimal Salary { get; set; }
    public string EmailId { get; set; } = string.Empty!;
    public DateOnly JoiningDate { get; set; }
    public string DepartmentId { get; set; } = string.Empty!;

    public string Status { get; set; } = string.Empty!;
}
