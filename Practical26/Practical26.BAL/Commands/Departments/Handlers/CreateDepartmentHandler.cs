namespace Practical26.BAL.Commands.Departments.Handlers;

public class CreateDepartmentHandler(IUnitOfWork unitOfWork, IDepartmentMapper departmentMapper, IFileLogger logger) : ICommandHandler<CreateDepartmentCommand, ApiResponse<Department>>
{
    private readonly IDepartmentWriteRepository _departmentWriteRepository = unitOfWork.DepartmentWriteRepository;
    public async Task<ApiResponse<Department>> HandleAsync(CreateDepartmentCommand command)
    {
        logger.Log("Creating new department.");

        var exists = await _departmentWriteRepository.GetByNameAsync(command.DepartmentName);
        if (exists)
        {
            logger.LogError($"Department already exists: {command.DepartmentName}", null);
            return ApiResponse<Department>.Failure("Record with same department name already exists.");
        }

        var department = departmentMapper.DepartmentCreateRequestDTOToDepartment(command);
        var created = await _departmentWriteRepository.AddAsync(department);

        await unitOfWork.SaveChangesAsync();

        logger.Log($"Department created with id: {created.Id}");
        return ApiResponse<Department>.Success(created, "Department created successfully.");
    }
}
