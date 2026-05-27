namespace Practical24.API.Controllers.v1;

[ApiController]
[Route("api/v{version:apiVersion}/departments")]
[ApiVersion("1.0")]
public class DepartmentController(IDepartmentService _departmentService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> GetAllDepartmentsAsync(string? id = null, bool isActive = true, int page = 1, int limit = 10)
    {
        var result = await _departmentService.GetAllDepartmentsAsync(id, isActive, page, limit);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment([FromBody] DepartmentCreateRequestDTO dto)
    {
        var result = await _departmentService.CreateNewDepartmentRecord(dto);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartment(string id, [FromBody] DepartmentUpdateRequestDTO dto)
    {
        var result = await _departmentService.UpdateDepartmentRecord(id, dto);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(string id)
    {
        var result = await _departmentService.DeleteDepartmentRecord(id);
        return Ok(result);
    }
}
