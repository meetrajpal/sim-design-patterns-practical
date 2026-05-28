namespace Practical25.BAL.Commands.Employees.Handlers;

public class UpdateEmployeeHandler(IUnitOfWork unitOfWork, IEmployeeMapper employeeMapper, IFileLogger logger) : IRequestHandler<UpdateEmployeeCommand, ApiResponse<string>>
{
    private readonly IEmployeeWriteRepository employeeWriteRepository = unitOfWork.EmployeeWriteRepository;
    public async Task<ApiResponse<string>> Handle(UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        logger.Log($"Updating employee: {command.Id}");

        if (!Guid.TryParse(command.Id, out var employeeId))
            return ApiResponse<string>.Failure("Invalid employee id format.", [$"Id must be a valid Guid: {command.Id}"]);

        var employee = await employeeWriteRepository.GetByIdAsync(employeeId, cancellationToken);
        if (employee is null)
            return ApiResponse<string>.Failure("Employee not found.", [$"No employee found with id: {employeeId}"]);

        if (!Guid.TryParse(command.DepartmentId, out var departmentId))
            return ApiResponse<string>.Failure("Invalid department id.");

        var departmentExists = await employeeWriteRepository.ExistsAsync(departmentId, cancellationToken);
        if (!departmentExists)
            return ApiResponse<string>.Failure("Department not found.");

        employeeMapper.EmployeeUpdateRequestDTOToEmployee(command, employee);
        employee.DepartmentId = departmentId;


        await employeeWriteRepository.UpdateAsync(employee, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        logger.Log($"Employee updated successfully with id: {employeeId}");
        return ApiResponse<string>.Success("Employee updated successfully.");
    }
}
