namespace Practical25.BAL.Commands.Departments.Handlers;

public class CreateDepartmentHandler(IUnitOfWork unitOfWork, IDepartmentMapper departmentMapper, IFileLogger logger) : IRequestHandler<CreateDepartmentCommand, ApiResponse<Department>>
{
    private readonly IDepartmentWriteRepository _departmentWriteRepository = unitOfWork.DepartmentWriteRepository;

    public async Task<ApiResponse<Department>> Handle(CreateDepartmentCommand command, CancellationToken cancellationToken)
    {
        logger.Log("Creating new department.");

        var exists = await _departmentWriteRepository.GetByNameAsync(command.DepartmentName, cancellationToken);
        if (exists)
        {
            logger.LogError($"Department already exists: {command.DepartmentName}", null);
            return ApiResponse<Department>.Failure("Record with same department name already exists.");
        }

        var department = departmentMapper.CreateDepartmentCommandToDepartment(command);
        var created = await _departmentWriteRepository.AddAsync(department, cancellationToken);

        await unitOfWork.SaveChangesAsync();

        logger.Log($"Department created with id: {created.Id}");
        return ApiResponse<Department>.Success(created, "Department created successfully.");
    }
}
