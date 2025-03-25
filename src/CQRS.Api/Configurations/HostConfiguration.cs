namespace CQRS.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask ConfigureAsync(this WebApplicationBuilder builder)
    {

        builder
            .AddConfigurationSettings()
            .AddInfrastructures()
            .AddPersistence()
            .AddExposers()
            .AddDevTools();

        return ValueTask.CompletedTask;
    }

    public static ValueTask ConfigureAsync(this WebApplication app)
    {

        app
            .UseDevTools()
            .UseExposers();

        return ValueTask.CompletedTask;
    }
}
