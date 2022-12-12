using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NavigationSample.Navigators;

namespace NavigationSample.HostBuilders
{
    static class AddNavigatorsHostBuilderExtension
    {
        public static IHostBuilder AddNavigators(this IHostBuilder host)
        {
            return host.ConfigureServices((context, services) =>
            {
                services.AddSingleton<INavigator, Navigator>();
            });
        } 
    }
}
