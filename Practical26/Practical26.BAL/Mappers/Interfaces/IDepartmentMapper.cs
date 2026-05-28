using Practical26.BAL.Queries.Departments;

namespace Practical26.BAL.Mappers.Interfaces;

public interface IDepartmentMapper
{

    GetAllDepartmentsQuery GetAllDepartmentsRequestDTOToGetAllDepartmentsQuery(GetAllDepartmentsRequestDTO dto);
    CreateDepartmentCommand CreateRequestDTOToCreateDepartmentCommand(DepartmentCreateRequestDTO dto);
    UpdateDepartmentCommand UpdateRequestDTOToUpdateDepartmentCommand(DepartmentUpdateRequestDTO dto);
    Department CreateDepartmentCommandToDepartment(CreateDepartmentCommand command);
    void DepartmentUpdateCommandToDepartment(UpdateDepartmentCommand command, Department department);
}
