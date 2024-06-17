

using Microsoft.AspNetCore.Mvc;

namespace POC.MongoDB2;

public static class ProgramExtensions
{
    public static WebApplicationBuilder AddSwaggerGen(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }
    public static WebApplicationBuilder MapControllers(this WebApplicationBuilder builder)
    {
        builder.Services.AddControllers();
        builder.Services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        return builder;
    }
    
    public static WebApplication ConfigureSwaggerAndControllers(this WebApplication app)
    {
        app
            .UseSwagger()
            .UseSwaggerUI(c =>
            {
                c.RoutePrefix = string.Empty;
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "POC.MongoDB2");
            })
            .UseRouting()
            .UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        
        return app;
    }
    
    public static WebApplication ConfigurePort(this WebApplication app)
    {
        var port = Environment.GetEnvironmentVariable("PORT") ?? "80";
        app.Urls.Add($"http://localhost:{port}");

        return app;
    }
}