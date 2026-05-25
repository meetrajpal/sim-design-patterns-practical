using Practical22.Domain.DTOs.Department;

namespace Practical22.Infrastructure.Mappers.Interfaces;

public interface IDepartmentMapper
{
    Department DepartmentCreateRequestDTOToDepartment(DepartmentCreateRequestDTO dto);

    void DepartmentUpdateRequestDTOToDepartment(DepartmentUpdateRequestDTO dto, Department department);
}
