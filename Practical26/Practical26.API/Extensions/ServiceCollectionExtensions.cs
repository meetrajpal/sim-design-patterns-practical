namespace Practical26.API.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }



    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddSingleton<IFileLogger, FileLogger>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();


        services.AddScoped<IQueryHandler<GetAllEmployeesQuery, ApiResponse<List<Employee>>>, GetAllEmployeesHandler>();
        services.AddScoped<ICommandHandler<CreateEmployeeCommand, ApiResponse<Employee>>, CreateEmployeeHandler>();
        services.AddScoped<ICommandHandler<DeleteEmployeeCommand, ApiResponse<string>>, DeleteEmployeeHandler>();
        services.AddScoped<ICommandHandler<UpdateEmployeeCommand, ApiResponse<string>>, UpdateEmployeeHandler>();

        services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
        services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();


        services.AddScoped<IQueryHandler<GetAllDepartmentsQuery, ApiResponse<List<Department>>>, GetAllDepartmentsHandler>();
        services.AddScoped<ICommandHandler<CreateDepartmentCommand, ApiResponse<Department>>, CreateDepartmentHandler>();
        services.AddScoped<ICommandHandler<DeleteDepartmentCommand, ApiResponse<string>>, DeleteDepartmentHandler>();
        services.AddScoped<ICommandHandler<UpdateDepartmentCommand, ApiResponse<string>>, UpdateDepartmentHandler>();

        services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
        services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();

        services.AddScoped<IEmployeeMapper, EmployeeMapper>();
        services.AddScoped<IDepartmentMapper, DepartmentMapper>();

        services.AddValidatorsFromAssembly(typeof(CreateEmployeeCommandValidator).Assembly);
        return services;
    }
}