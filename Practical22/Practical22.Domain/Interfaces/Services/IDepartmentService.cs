using Practical22.Domain.DTOs.Department;
using Practical22.Domain.Entities;

namespace Practical22.Domain.Interfaces.Services;

public interface IDepartmentService
{
    Task<ApiResponse<List<Department>>> GetAllDepartmentsAsync(string? id, bool isActive, int page, int limit);

    Task<ApiResponse<Department>> CreateNewDepartmentRecord(DepartmentCreateRequestDTO department);

    Task<ApiResponse<string>> UpdateDepartmentRecord(string id, DepartmentUpdateRequestDTO department);

    Task<ApiResponse<string>> DeleteDepartmentRecord(string id);

}
