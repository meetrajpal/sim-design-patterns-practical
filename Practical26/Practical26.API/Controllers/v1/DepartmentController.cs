using Practical26.Domain.DTOs.Department;

namespace Practical26.API.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/departments")]
[ApiVersion("1.0")]
public class DepartmentController(
    IQueryHandler<GetAllDepartmentsQuery, ApiResponse<List<Department>>> departmentQueryHandler,
    ICommandHandler<CreateDepartmentCommand, ApiResponse<Department>> createCommandHandler,
    ICommandHandler<UpdateDepartmentCommand, ApiResponse<string>> updateCommandHandler,
    ICommandHandler<DeleteDepartmentCommand, ApiResponse<string>> deleteCommandHandler,
    IDepartmentMapper departmentMapper,
    IValidator<CreateDepartmentCommand> createCommandValidator,
    IValidator<UpdateDepartmentCommand> updateCommandValidator,
    IValidator<DeleteDepartmentCommand> deleteCommandValidator

    ) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllDepartmentsAsync([FromQuery] GetAllDepartmentsRequestDTO dto)
    {
        var query = departmentMapper.GetAllDepartmentsRequestDTOToGetAllDepartmentsQuery(dto);

        var result = await departmentQueryHandler.HandleAsync(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand dto)
    {
        var command = departmentMapper.CreateRequestDTOToCreateDepartmentCommand(dto);

        var validationResult = await createCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await createCommandHandler.HandleAsync(dto);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDepartment([FromQuery] string id, [FromBody] DepartmentUpdateRequestDTO dto)
    {
        var command = departmentMapper.UpdateRequestDTOToUpdateDepartmentCommand(dto);
        command.Id = id;
        var validationResult = await updateCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await updateCommandHandler.HandleAsync(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDepartment([FromQuery] string id)
    {
        DeleteDepartmentCommand command = new() { Id = id };
        var validationResult = await deleteCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await deleteCommandHandler.HandleAsync(command);
        return Ok(result);
    }
}
