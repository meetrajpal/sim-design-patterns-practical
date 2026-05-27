namespace Practical26.BAL.Queries.Departments.Handler;

public class GetAllDepartmentsHandler(IDepartmentReadRepository departmentReadRepository, IFileLogger logger) : IQueryHandler<GetAllDepartmentsQuery, ApiResponse<List<Department>>>
{

    public async Task<ApiResponse<List<Department>>> HandleAsync(GetAllDepartmentsQuery query)
    {
        logger.Log("Fetching department records.");

        if (string.IsNullOrWhiteSpace(query.Id))
            return await departmentReadRepository.GetAllAsync(null, query.IsActive, query.Page, query.Limit);

        if (!Guid.TryParse(query.Id, out var parsedId))
        {
            logger.LogError($"Invalid department id format: {query.Id}", null);
            return ApiResponse<List<Department>>.Failure("Error occured while retrieving departments.", [$"Invalid Guid format: {query.Id}"]);
        }

        var result = await departmentReadRepository.GetAllAsync(parsedId, query.IsActive, query.Page, query.Limit);
        logger.Log($"Department fetched successfully with id: {parsedId}");
        return result;
    }
}
