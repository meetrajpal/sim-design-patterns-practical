using Practical25.BAL.Queries.Employees;

namespace Practical25.BAL.Mappers;

[Mapper]
public partial class EmployeeMapper : IEmployeeMapper
{
    public partial GetAllEmployeesQuery GetAllEmployeesRequestDTOToGetAllEmployeesQuery(GetAllEmployeesRequestDTO dto);
    public partial CreateEmployeeCommand CreateRequestDTOToCreateEmployeeCommand(EmployeeCreateRequestDTO dto);

    [MapperIgnoreTarget(nameof(Employee.Id))]
    public partial UpdateEmployeeCommand UpdateRequestDTOToUpdateEmployeeCommand(EmployeeUpdateRequestDTO dto);

    [MapperIgnoreSource(nameof(Employee.Id))]
    [MapperIgnoreTarget(nameof(Employee.Id))]
    [MapperIgnoreTarget(nameof(Employee.CreatedAt))]
    [MapperIgnoreTarget(nameof(Employee.UpdatedAt))]
    [MapperIgnoreTarget(nameof(Employee.Department))]
    public partial void EmployeeUpdateCommandToEmployee(UpdateEmployeeCommand command, Employee Employee);

    [MapperIgnoreTarget(nameof(Employee.Id))]
    [MapperIgnoreTarget(nameof(Employee.CreatedAt))]
    [MapperIgnoreTarget(nameof(Employee.UpdatedAt))]
    [MapperIgnoreTarget(nameof(Employee.IsActive))]
    [MapperIgnoreTarget(nameof(Employee.Department))]
    public partial Employee CreateEmployeeCommandToEmployee(CreateEmployeeCommand command);
}
