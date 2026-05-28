using Practical25.Domain.DTOs.Department;

namespace Practical25.API.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/departments")]
[ApiVersion("1.0")]
public class DepartmentController(
    IMediator mediator,
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
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] CreateDepartmentCommand dto)
    {
        var command = departmentMapper.CreateRequestDTOToCreateDepartmentCommand(dto);
        var validationResult = await createCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await mediator.Send(command);
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

        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDepartment([FromQuery] string id)
    {
        DeleteDepartmentCommand command = new() { Id = id };
        var validationResult = await deleteCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await mediator.Send(command);
        return Ok(result);
    }
}
