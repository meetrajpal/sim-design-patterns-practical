namespace Practical26.BAL.Commands.Departments.Handlers;

public class UpdateDepartmentHandler(IUnitOfWork unitOfWork, IDepartmentMapper departmentMapper, IFileLogger logger) : ICommandHandler<UpdateDepartmentCommand, ApiResponse<string>>
{
    private readonly IDepartmentWriteRepository _departmentRepository = unitOfWork.DepartmentWriteRepository;
    public async Task<ApiResponse<string>> HandleAsync(UpdateDepartmentCommand command)
    {
        logger.Log($"Updating department: {command.Id}");

        if (!Guid.TryParse(command.Id, out var parsedId))
            return ApiResponse<string>.Failure("Invalid department id format.", [$"Id must be a valid Guid: {command.Id}"]);

        var department = await _departmentRepository.GetByIdAsync(parsedId);
        if (department is null)
            return ApiResponse<string>.Failure("Department not found.", [$"No department found with id: {parsedId}"]);

        departmentMapper.DepartmentUpdateCommandToDepartment(command, department);

        await _departmentRepository.UpdateAsync(department);
        await unitOfWork.SaveChangesAsync();

        logger.Log($"Department updated: {parsedId}");
        return ApiResponse<string>.Success("Department updated successfully.");
    }
}
