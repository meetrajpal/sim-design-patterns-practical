namespace Practical25.BAL.Commands.Employees.Handlers;

public class CreateEmployeeHandler(IUnitOfWork unitOfWork, IEmployeeMapper employeeMapper, IFileLogger logger) : IRequestHandler<CreateEmployeeCommand, ApiResponse<Employee>>
{
    private readonly IEmployeeWriteRepository employeeWriteRepository = unitOfWork.EmployeeWriteRepository;
    private readonly IDepartmentWriteRepository departmentWriteRepository = unitOfWork.DepartmentWriteRepository;
    public async Task<ApiResponse<Employee>> Handle(CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        logger.Log("Creating new employee record.");

        if (!Guid.TryParse(command.DepartmentId, out var departmentId))
            return ApiResponse<Employee>.Failure("Invalid department id.");

        var departmentExists = await departmentWriteRepository.ExistsAsync(departmentId, cancellationToken);
        if (!departmentExists)
            return ApiResponse<Employee>.Failure("Department not found.");

        var employee = employeeMapper.CreateEmployeeCommandToEmployee(command);
        employee.DepartmentId = departmentId;

        var created = await employeeWriteRepository.AddAsync(employee, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        logger.Log($"Employee created successfully with id: {created.Id}");
        return ApiResponse<Employee>.Success(created, "Employee created successfully.");
    }
}
