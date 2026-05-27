using Practical24.Domain.DTOs.Employee;
using Practical24.Domain.Entities;

namespace Practical24.Domain.Interfaces.Services;

public interface IEmployeeService
{
    Task<ApiResponse<List<Employee>>> GetAllEmployeesAsync(string? id, bool isActive, int page, int limit);

    Task<ApiResponse<Employee>> CreateNewEmployeeRecord(EmployeeCreateRequestDTO employee);

    Task<ApiResponse<string>> UpdateEmployeeRecord(string id, EmployeeUpdateRequestDTO employee);

    Task<ApiResponse<string>> DeleteEmployeeRecord(string id);
}
