using Practical25.BAL.Queries.Employees;

namespace Practical25.BAL.Mappers.Interfaces;

public interface IEmployeeMapper
{
    GetAllEmployeesQuery GetAllEmployeesRequestDTOToGetAllEmployeesQuery(GetAllEmployeesRequestDTO dto);
    CreateEmployeeCommand CreateRequestDTOToCreateEmployeeCommand(EmployeeCreateRequestDTO dto);
    UpdateEmployeeCommand UpdateRequestDTOToUpdateEmployeeCommand(EmployeeUpdateRequestDTO dto);
    Employee CreateEmployeeCommandToEmployee(CreateEmployeeCommand command);
    void EmployeeUpdateCommandToEmployee(UpdateEmployeeCommand command, Employee Employee);
}
