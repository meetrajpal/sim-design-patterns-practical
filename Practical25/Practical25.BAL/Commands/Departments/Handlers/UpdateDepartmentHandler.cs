namespace Practical25.BAL.Commands.Departments.Handlers;

public class UpdateDepartmentHandler(IUnitOfWork unitOfWork, IDepartmentMapper departmentMapper, IFileLogger logger) : IRequestHandler<UpdateDepartmentCommand, ApiResponse<string>>
{
    private readonly IDepartmentWriteRepository _departmentRepository = unitOfWork.DepartmentWriteRepository;
    public async Task<ApiResponse<string>> Handle(UpdateDepartmentCommand command, CancellationToken cancellationToken)
    {
        logger.Log($"Updating department: {command.Id}");

        if (!Guid.TryParse(command.Id, out var parsedId))
            return ApiResponse<string>.Failure("Invalid department id format.", [$"Id must be a valid Guid: {command.Id}"]);

        var department = await _departmentRepository.GetByIdAsync(parsedId, cancellationToken);
        if (department is null)
            return ApiResponse<string>.Failure("Department not found.", [$"No department found with id: {parsedId}"]);

        departmentMapper.DepartmentUpdateRequestDTOToDepartment(command, department);
        department.UpdatedAt = DateTime.UtcNow;

        await _departmentRepository.UpdateAsync(department, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        logger.Log($"Department updated: {parsedId}");
        return ApiResponse<string>.Success("Department updated successfully.");
    }
}
