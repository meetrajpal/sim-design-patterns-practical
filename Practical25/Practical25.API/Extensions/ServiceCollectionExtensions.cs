namespace Practical25.API.Extensions;

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

        services.AddScoped<IEmployeeReadRepository, EmployeeReadRepository>();
        services.AddScoped<IEmployeeWriteRepository, EmployeeWriteRepository>();

        services.AddScoped<IDepartmentReadRepository, DepartmentReadRepository>();
        services.AddScoped<IDepartmentWriteRepository, DepartmentWriteRepository>();

        services.AddScoped<IEmployeeMapper, EmployeeMapper>();
        services.AddScoped<IDepartmentMapper, DepartmentMapper>();

        services.AddValidatorsFromAssembly(typeof(CreateEmployeeCommandValidator).Assembly);

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateEmployeeCommand).Assembly));

        return services;
    }
}