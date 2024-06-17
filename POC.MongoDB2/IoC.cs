using Microsoft.Extensions.Options;
using MongoDB.Driver;
using POC.MongoDB2.Data;
using POC.MongoDB2.Data.Repositories;
using POC.MongoDB2.Data.Repositories.Interfaces;

namespace POC.MongoDB2;

public static class IoC
{
    private static IConfiguration _configuration { get; set; }
    
    public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        _configuration = configuration;

        services.RegisterServices();

        return services;
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.Configure<MongoDBSettings>(_configuration.GetSection("MongoDBSettings"));
        
        services.AddSingleton<IMongoClient, MongoClient>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
            return new MongoClient(settings.ConnectionString);
        });

        services.AddScoped<IMongoDatabase>(sp =>
        {
            var settings = sp.GetRequiredService<IOptions<MongoDBSettings>>().Value;
            var client = sp.GetRequiredService<IMongoClient>();
            
            return client.GetDatabase(settings.DatabaseName);
        });

        services.AddScoped<IGamesRepository, GameRepository>();
        services.AddScoped<IColorsRepository, ColorsRepository>();
        
        return services;
    }  
}