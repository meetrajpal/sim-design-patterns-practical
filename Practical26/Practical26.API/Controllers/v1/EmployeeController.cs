using Practical26.Domain.DTOs.Employee;

namespace Practical26.API.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/employees")]
[ApiVersion("1.0")]
public class EmployeeController(
    IQueryHandler<GetAllEmployeesQuery, ApiResponse<List<Employee>>> employeeQueryHandler,
    ICommandHandler<CreateEmployeeCommand, ApiResponse<Employee>> createCommandHandler,
    ICommandHandler<UpdateEmployeeCommand, ApiResponse<string>> updateCommandHandler,
    ICommandHandler<DeleteEmployeeCommand, ApiResponse<string>> deleteCommandHandler,
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

        var result = await employeeQueryHandler.HandleAsync(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateRequestDTO dto)
    {
        var command = employeeMapper.CreateRequestDTOToCreateEmployeeCommand(dto);

        var validationResult = await createCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await createCommandHandler.HandleAsync(command);
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

        var result = await updateCommandHandler.HandleAsync(command);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEmployee([FromQuery] string id)
    {
        var command = new DeleteEmployeeCommand() { Id = id };

        var validationResult = await deleteCommandValidator.ValidateAsync(command);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var result = await deleteCommandHandler.HandleAsync(command);
        return Ok(result);
    }
}
