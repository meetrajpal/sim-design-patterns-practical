using Practical25.Domain.DTOs.Employee;

namespace Practical25.API.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/employees")]
[ApiVersion("1.0")]
public class EmployeeController(
    IMediator mediator,
    IEmployeeMapper employeeMapper,
    IValidator<CreateEmployeeCommand> createCommandValidator,
    IValidator<UpdateEmployeeCommand> updateCommandValidator,
    IValidator<DeleteEmployeeCommand> deleteCommandValidator
) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllEmployeesAsync([FromQuery] GetAllEmployeesRequestDTO dto)
    {
        var query = employeeMapper.GetAllEmployeesRequestDTOToGetAllEmployeesQuery(dto);
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateRequestDTO dto)
    {
        var command = employeeMapper.CreateRequestDTOToCreateEmployeeCommand(dto);
        var validationResult = await createCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateEmployee([FromQuery] string id, [FromBody] EmployeeUpdateRequestDTO dto)
    {
        var command = employeeMapper.UpdateRequestDTOToUpdateEmployeeCommand(dto);
        command.Id = id;

        var validationResult = await updateCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEmployee([FromQuery] string id)
    {
        var command = new DeleteEmployeeCommand() { Id = id };
        var validationResult = await deleteCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await mediator.Send(command);
        return Ok(result);
    }
}
