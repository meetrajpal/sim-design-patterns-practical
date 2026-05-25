namespace Practical22.API.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/employees")]
[ApiVersion("1.0")]
public class EmployeeController(IEmployeeService _employeeService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllEmployeesAsync(string? id = null, bool isActive = true, int page = 1, int limit = 10)
    {
        var result = await _employeeService.GetAllEmployeesAsync(id, isActive, page, limit);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateRequestDTO dto)
    {
        var result = await _employeeService.CreateNewEmployeeRecord(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(string id, [FromBody] EmployeeUpdateRequestDTO dto)
    {
        var result = await _employeeService.UpdateEmployeeRecord(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(string id)
    {
        var result = await _employeeService.DeleteEmployeeRecord(id);
        return Ok(result);
    }

}
