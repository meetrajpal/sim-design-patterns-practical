namespace Practical24.BAL.Services;

public class EmployeeService(IUnitOfWork unitOfWork, IEmployeeMapper employeeMapper, IFileLogger logger) : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = unitOfWork.EmployeeRepository;
    private readonly IDepartmentRepository _departmentRepository = unitOfWork.DepartmentRepository;

    public async Task<ApiResponse<List<Employee>>> GetAllEmployeesAsync(string? id = null, bool isActive = true, int page = 1, int limit = 10)
    {
        logger.Log("Fetching employee records.");

        if (string.IsNullOrWhiteSpace(id))
            return await _employeeRepository.GetAllAsync(null, isActive, page, limit);

        if (!Guid.TryParse(id, out var employeeId))
        {
            logger.LogError($"Invalid employee id format: {id}", null);
            return ApiResponse<List<Employee>>.Failure(
                "Error occured while retrieving employee.",
                [$"Invalid Guid format: {id}"]
            );
        }

        var result = await _employeeRepository.GetAllAsync(employeeId, isActive, page, limit);
        logger.Log($"Employee fetched successfully with id: {employeeId}");
        return result;
    }

    public async Task<ApiResponse<Employee>> CreateNewEmployeeRecord(EmployeeCreateRequestDTO dto)
    {
        logger.Log("Creating new employee record.");

        if (!Guid.TryParse(dto.DepartmentId, out var departmentId))
            return ApiResponse<Employee>.Failure("Invalid department id.");

        var departmentExists = await _departmentRepository.ExistsAsync(departmentId);
        if (!departmentExists)
            return ApiResponse<Employee>.Failure("Department not found.");

        var employee = employeeMapper.EmployeeCreateRequestDTOToEmployee(dto);
        employee.DepartmentId = departmentId;

        var created = await _employeeRepository.AddAsync(employee);
        await unitOfWork.SaveChangesAsync();

        logger.Log($"Employee created successfully with id: {created.Id}");
        return ApiResponse<Employee>.Success(created, "Employee created successfully.");
    }

    public async Task<ApiResponse<string>> UpdateEmployeeRecord(string id, EmployeeUpdateRequestDTO dto)
    {
        logger.Log($"Updating employee: {id}");

        if (!Guid.TryParse(id, out var employeeId))
            return ApiResponse<string>.Failure("Invalid employee id format.", [$"Id must be a valid Guid: {id}"]);

        var employee = await _employeeRepository.GetByIdAsync(employeeId);
        if (employee is null)
            return ApiResponse<string>.Failure("Employee not found.", [$"No employee found with id: {employeeId}"]);

        if (!Guid.TryParse(dto.DepartmentId, out var departmentId))
            return ApiResponse<string>.Failure("Invalid department id.");

        var departmentExists = await _departmentRepository.ExistsAsync(departmentId);
        if (!departmentExists)
            return ApiResponse<string>.Failure("Department not found.");

        employeeMapper.EmployeeUpdateRequestDTOToEmployee(dto, employee);
        employee.DepartmentId = departmentId;

        await _employeeRepository.UpdateAsync(employee);
        await unitOfWork.SaveChangesAsync();

        logger.Log($"Employee updated successfully with id: {employeeId}");
        return ApiResponse<string>.Success("Employee updated successfully.");
    }

    public async Task<ApiResponse<string>> DeleteEmployeeRecord(string id)
    {
        logger.Log($"Deleting employee: {id}");

        if (!Guid.TryParse(id, out var employeeId))
            return ApiResponse<string>.Failure("Invalid employee id format.", [$"Id must be a valid Guid: {id}"]);

        var employee = await _employeeRepository.GetByIdAsync(employeeId);
        if (employee is null)
            return ApiResponse<string>.Failure("Employee not found.", [$"No employee found with id: {employeeId}"]);

        await _employeeRepository.DeleteAsync(employee);
        await unitOfWork.SaveChangesAsync();

        logger.Log($"Employee deleted successfully with id: {employeeId}");
        return ApiResponse<string>.Success("Employee deleted successfully.");
    }
}