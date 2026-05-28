using Practical26.BAL.Queries.Departments;

namespace Practical26.BAL.Mappers;

[Mapper]
public partial class DepartmentMapper : IDepartmentMapper
{
    public partial GetAllDepartmentsQuery GetAllDepartmentsRequestDTOToGetAllDepartmentsQuery(GetAllDepartmentsRequestDTO dto);
    public partial CreateDepartmentCommand CreateRequestDTOToCreateDepartmentCommand(DepartmentCreateRequestDTO dto);

    [MapperIgnoreTarget(nameof(Department.Id))]
    public partial UpdateDepartmentCommand UpdateRequestDTOToUpdateDepartmentCommand(DepartmentUpdateRequestDTO dto);

    [MapperIgnoreTarget(nameof(Department.Id))]
    [MapperIgnoreTarget(nameof(Department.CreatedAt))]
    [MapperIgnoreTarget(nameof(Department.UpdatedAt))]
    [MapperIgnoreTarget(nameof(Department.IsActive))]
    [MapperIgnoreTarget(nameof(Department.Employees))]
    public partial Department CreateDepartmentCommandToDepartment(CreateDepartmentCommand command);

    [MapperIgnoreSource(nameof(Department.Id))]
    [MapperIgnoreTarget(nameof(Department.Id))]
    [MapperIgnoreTarget(nameof(Department.CreatedAt))]
    [MapperIgnoreTarget(nameof(Department.UpdatedAt))]
    [MapperIgnoreTarget(nameof(Department.Employees))]
    public partial void DepartmentUpdateCommandToDepartment(UpdateDepartmentCommand command, Department department);
}
