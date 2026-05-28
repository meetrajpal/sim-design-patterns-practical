namespace Practical25.BAL.Commands.Departments.Handlers;

public class DeleteDepartmentHandler(IUnitOfWork unitOfWork, IFileLogger logger) : IRequestHandler<DeleteDepartmentCommand, ApiResponse<string>>
{
    private readonly IDepartmentWriteRepository _departmentWriteRepository = unitOfWork.DepartmentWriteRepository;
    public async Task<ApiResponse<string>> Handle(DeleteDepartmentCommand command, CancellationToken cancellationToken)
    {
        logger.Log($"Deleting department: {command.Id}");

        if (!Guid.TryParse(command.Id, out var parsedId))
            return ApiResponse<string>.Failure("Invalid department id format.", [$"Id must be a valid Guid: {command.Id}"]);

        var department = await _departmentWriteRepository.GetByIdAsync(parsedId, cancellationToken);
        if (department is null)
            return ApiResponse<string>.Failure("Department not found.", [$"No department found with id: {parsedId}"]);

        await _departmentWriteRepository.DeleteAsync(department, cancellationToken);
        await unitOfWork.SaveChangesAsync();

        logger.Log($"Department deleted: {parsedId}");
        return ApiResponse<string>.Success("Department deleted successfully.");
    }
}
