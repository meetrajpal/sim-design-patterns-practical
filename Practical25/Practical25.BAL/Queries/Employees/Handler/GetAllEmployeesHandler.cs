namespace Practical25.BAL.Queries.Employees.Handler;

public class GetAllEmployeesHandler(IEmployeeReadRepository EmployeeReadRepository, IFileLogger logger) : IRequestHandler<GetAllEmployeesQuery, ApiResponse<List<Employee>>>
{

    public async Task<ApiResponse<List<Employee>>> Handle(GetAllEmployeesQuery query, CancellationToken cancellationToken = default)
    {
        logger.Log("Fetching Employee records.");

        if (string.IsNullOrWhiteSpace(query.Id))
            return await EmployeeReadRepository.GetAllAsync(null, query.IsActive, query.Page, query.Limit, cancellationToken);

        if (!Guid.TryParse(query.Id, out var parsedId))
        {
            logger.LogError($"Invalid Employee id format: {query.Id}", null);
            return ApiResponse<List<Employee>>.Failure("Error occured while retrieving Employees.", [$"Invalid Guid format: {query.Id}"]);
        }

        var result = await EmployeeReadRepository.GetAllAsync(parsedId, query.IsActive, query.Page, query.Limit, cancellationToken);
        logger.Log($"Employee fetched successfully with id: {parsedId}");
        return result;
    }
}
