using Microsoft.Extensions.DependencyInjection;

namespace TA_FinalTask;

public static partial class ServiceLocator
{
    private static IServiceProvider ConfigureServices()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<ILoggerFactory, LoggerFactory>();
        serviceCollection.AddSingleton<IDriverFactory, DriverFactory>();
        serviceCollection.AddSingleton<IPageFactory  , PageFactory>();

        return serviceCollection.BuildServiceProvider();
    }
}