namespace Practical26.API.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/departments")]
[ApiVersion("1.0")]
public class DepartmentController(
    IQueryHandler<GetAllDepartmentsQuery, ApiResponse<List<Department>>> departmentQueryHandler,
    ICommandHandler<CreateDepartmentCommand, ApiResponse<Department>> createCommandHandler,
    ICommandHandler<UpdateDepartmentCommand, ApiResponse<string>> updateCommandHandler,
    ICommandHandler<DeleteDepartmentCommand, ApiResponse<string>> deleteCommandHandler,
    IValidator<CreateDepartmentCommand> createCommandValidator,
    IValidator<UpdateDepartmentCommand> updateCommandValidator,
    IValidator<DeleteDepartmentCommand> deleteCommandValidator

    ) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllDepartmentsAsync([FromQuery] GetAllDepartmentsQuery query)
    {
        var result = await departmentQueryHandler.HandleAsync(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
    {
        var validationResult = await createCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await createCommandHandler.HandleAsync(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDepartment([FromQuery] string id, [FromBody] UpdateDepartmentCommand command)
    {
        command.Id = id;

        var validationResult = await updateCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await updateCommandHandler.HandleAsync(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDepartment([FromQuery] DeleteDepartmentCommand command)
    {
        var validationResult = await deleteCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await deleteCommandHandler.HandleAsync(command);
        return Ok(result);
    }
}
