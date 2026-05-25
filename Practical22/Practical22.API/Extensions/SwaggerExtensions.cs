namespace Practical22.API.Extensions;

public static class SwaggerExtensions
{
    public static IServiceCollection AddSwaggerService(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Practical 22 API",
                Version = "v1",
                Description = "Practical 22 API"
            });
        });

        return services;
    }

    public static WebApplication UseSwaggerWithVersioning(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "Practical 22 API V1");
        });

        return app;
    }
}