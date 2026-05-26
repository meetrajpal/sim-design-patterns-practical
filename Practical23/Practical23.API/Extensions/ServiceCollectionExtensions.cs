namespace Practical23.API.Extensions;

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
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IDepartmentService, DepartmentService>();
        services.AddScoped<IEmployeeMapper, EmployeeMapper>();
        services.AddScoped<IDepartmentMapper, DepartmentMapper>();

        return services;
    }

    public static IServiceCollection RegisterApplicationFactories(this IServiceCollection services)
    {
        IndoorAbstractFactory indoorStore = new();
        indoorStore.Register("it", new ITOvertimeCalcFactory());
        indoorStore.Register("hr", new HROvertimeCalcFactory());


        OutdoorAbstractFactory outdoorStore = new();
        outdoorStore.Register("sales", new SalesOvertimeCalcFactory());
        outdoorStore.Register("onsite", new OnSiteOvertimeCalcFactory());


        AbstractFactoryStore store = new();
        store.Register("it", indoorStore);
        store.Register("hr", indoorStore);
        store.Register("sales", outdoorStore);
        store.Register("onsite", outdoorStore);

        services.AddSingleton<IAbstractFactoryStore>(store);

        return services;
    }
}