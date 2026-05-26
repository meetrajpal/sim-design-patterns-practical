namespace Practical23.BAL.Services;

public class DepartmentService(IUnitOfWork unitOfWork, IDepartmentMapper departmentMapper, IFileLogger logger) : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository = unitOfWork.DepartmentRepository;

    public async Task<ApiResponse<List<Department>>> GetAllDepartmentsAsync(string? id = null, bool isActive = true, int page = 1, int limit = 10)
    {
        logger.Log("Fetching department records.");

        if (string.IsNullOrWhiteSpace(id))
            return await _departmentRepository.GetAllAsync(null, isActive, page, limit);

        if (!Guid.TryParse(id, out var parsedId))
        {
            logger.LogError($"Invalid department id format: {id}", null);
            return ApiResponse<List<Department>>.Failure("Error occured while retrieving departments.", [$"Invalid Guid format: {id}"]);
        }

        var result = await _departmentRepository.GetAllAsync(parsedId, isActive, page, limit);
        logger.Log($"Department fetched successfully with id: {parsedId}");
        return result;
    }

    public async Task<ApiResponse<Department>> CreateNewDepartmentRecord(DepartmentCreateRequestDTO dto)
    {
        logger.Log("Creating new department.");

        var exists = await _departmentRepository.GetByNameAsync(dto.DepartmentName);
        if (exists)
        {
            logger.LogError($"Department already exists: {dto.DepartmentName}", null);
            return ApiResponse<Department>.Failure("Record with same department name already exists.");
        }

        var department = departmentMapper.DepartmentCreateRequestDTOToDepartment(dto);
        var created = await _departmentRepository.AddAsync(department);

        await unitOfWork.SaveChangesAsync();

        logger.Log($"Department created with id: {created.Id}");
        return ApiResponse<Department>.Success(created, "Department created successfully.");
    }

    public async Task<ApiResponse<string>> UpdateDepartmentRecord(string id, DepartmentUpdateRequestDTO dto)
    {
        logger.Log($"Updating department: {id}");

        if (!Guid.TryParse(id, out var parsedId))
            return ApiResponse<string>.Failure("Invalid department id format.", [$"Id must be a valid Guid: {id}"]);

        var department = await _departmentRepository.GetByIdAsync(parsedId);
        if (department is null)
            return ApiResponse<string>.Failure("Department not found.", [$"No department found with id: {parsedId}"]);

        departmentMapper.DepartmentUpdateRequestDTOToDepartment(dto, department);
        department.UpdatedAt = DateTime.UtcNow;

        await _departmentRepository.UpdateAsync(department);
        await unitOfWork.SaveChangesAsync();

        logger.Log($"Department updated: {parsedId}");
        return ApiResponse<string>.Success("Department updated successfully.");
    }

    public async Task<ApiResponse<string>> DeleteDepartmentRecord(string id)
    {
        logger.Log($"Deleting department: {id}");

        if (!Guid.TryParse(id, out var parsedId))
            return ApiResponse<string>.Failure("Invalid department id format.", [$"Id must be a valid Guid: {id}"]);

        var department = await _departmentRepository.GetByIdAsync(parsedId);
        if (department is null)
            return ApiResponse<string>.Failure("Department not found.", [$"No department found with id: {parsedId}"]);

        await _departmentRepository.DeleteAsync(department);
        await unitOfWork.SaveChangesAsync();

        logger.Log($"Department deleted: {parsedId}");
        return ApiResponse<string>.Success("Department deleted successfully.");
    }
}