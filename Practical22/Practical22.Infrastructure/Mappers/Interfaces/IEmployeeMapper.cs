using Practical22.Domain.DTOs.Employee;

namespace Practical22.Infrastructure.Mappers.Interfaces;

public interface IEmployeeMapper
{
    Employee EmployeeCreateRequestDTOToEmployee(EmployeeCreateRequestDTO dto);
    void EmployeeUpdateRequestDTOToEmployee(EmployeeUpdateRequestDTO dto, Employee employee);
}
