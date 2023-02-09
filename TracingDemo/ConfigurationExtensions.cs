internal static class ConfigurationExtensions
{
    public static void AddInstrumentation(this IServiceCollection services)
    {
        services.AddSingleton<IInstrumentation, EventSourceInstrumentation>();
    }

    public static void AddDemoServices(this IServiceCollection services)
    {
        services.AddScoped<IDemoService, DemoService>();
    }
}
