using Microsoft.Extensions.DependencyInjection;

namespace TA_FinalTask;

public static partial class ServiceLocator
{
    private static readonly IServiceProvider _serviceProvider = ConfigureServices();

    public static T GetService<T>() where T : notnull
    {
        return _serviceProvider.GetRequiredService<T>();
    }
}