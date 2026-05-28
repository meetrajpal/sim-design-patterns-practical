namespace Practical25.API.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/departments")]
[ApiVersion("1.0")]
public class DepartmentController(
    IMediator mediator,
    IValidator<CreateDepartmentCommand> createCommandValidator,
    IValidator<UpdateDepartmentCommand> updateCommandValidator,
    IValidator<DeleteDepartmentCommand> deleteCommandValidator

    ) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllDepartmentsAsync([FromQuery] GetAllDepartmentsQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand command)
    {
        var validationResult = await createCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDepartment([FromQuery] string id, [FromBody] UpdateDepartmentCommand command)
    {
        command.Id = id;

        var validationResult = await updateCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDepartment([FromQuery] DeleteDepartmentCommand command)
    {
        var validationResult = await deleteCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await mediator.Send(command);
        return Ok(result);
    }
}
