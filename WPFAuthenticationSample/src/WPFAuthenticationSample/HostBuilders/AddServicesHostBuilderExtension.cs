using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WPFAuthenticationSample.Services.AccountService;
using WPFAuthenticationSample.Services.AuthenticationService;
using WPFAuthenticationSample.Services.Authenticators;
using WPFAuthenticationSample.Services.Navigators;

namespace WPFAuthenticationSample.HostBuilders
{
    public static class AddServicesHostBuilderExtension
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                services.AddSingleton<IAccountService, AccountService>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
            });

            return host;
        }
    }
}
