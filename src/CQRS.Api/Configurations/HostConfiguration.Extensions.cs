using CQRS.Api.Persistence.DataContext;
using CQRS.Api.Persistence.Repositories;
using CQRS.Api.Settings;
using MongoDB.Driver;

namespace CQRS.Api.Configurations;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddConfigurationSettings(this WebApplicationBuilder builder)
    {
        
        return builder;
    }
    
    private static WebApplicationBuilder AddInfrastructures(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddMediatR(c =>
            {
                c.RegisterServicesFromAssembly(typeof(Program).Assembly);
            });
        return builder;
    }

    private static WebApplicationBuilder AddPersistence(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .Configure<MongoDbSettings>(builder.Configuration.GetSection(nameof(MongoDbSettings)));
    
        builder
            .Services
            .AddSingleton<AppDbContext>()
            .AddSingleton<IMongoClient>(s =>
            {
                var setting = builder.Configuration.GetSection(nameof(MongoDbSettings)).Get<MongoDbSettings>();
                return new MongoClient(setting.ConnectionStrings);
            });

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddRouting(o =>
            {
                o.LowercaseUrls = true;
                o.LowercaseQueryStrings = true;
            })
            .AddControllers();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddEndpointsApiExplorer()
            .AddSwaggerGen();
        return builder;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app
            .UseSwagger()
            .UseSwaggerUI();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app
            .MapControllers();
        return app;
    }
}
