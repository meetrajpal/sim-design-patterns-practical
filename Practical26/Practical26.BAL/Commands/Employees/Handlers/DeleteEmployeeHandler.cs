namespace Practical26.BAL.Commands.Employees.Handlers;

public class DeleteEmployeeHandler(IUnitOfWork unitOfWork, IFileLogger logger) : ICommandHandler<DeleteEmployeeCommand, ApiResponse<string>>
{
    private readonly IEmployeeWriteRepository employeeWriteRepository = unitOfWork.EmployeeWriteRepository;
    public async Task<ApiResponse<string>> HandleAsync(DeleteEmployeeCommand command)
    {
        logger.Log($"Deleting employee: {command.Id}");

        if (!Guid.TryParse(command.Id, out var employeeId))
            return ApiResponse<string>.Failure("Invalid employee id format.", [$"Id must be a valid Guid: {command.Id}"]);

        var employee = await employeeWriteRepository.GetByIdAsync(employeeId);
        if (employee is null)
            return ApiResponse<string>.Failure("Employee not found.", [$"No employee found with id: {employeeId}"]);

        await employeeWriteRepository.DeleteAsync(employee);
        await unitOfWork.SaveChangesAsync();

        logger.Log($"Employee deleted successfully with id: {employeeId}");
        return ApiResponse<string>.Success("Employee deleted successfully.");
    }
}
