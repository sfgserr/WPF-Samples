using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using WPFAuthenticationSample.Services.Authenticators;
using WPFAuthenticationSample.Services.Navigators;
using WPFAuthenticationSample.ViewModels;

namespace WPFAuthenticationSample.HostBuilders
{
    public static class AddViewModelsHostBuilderExtension
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {  
                services.AddScoped<HomeViewModel>();
                services.AddScoped<LoginViewModel>();
                services.AddScoped<RegisterViewModel>();
                services.AddTransient<MainViewModel>();

                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => CreateHomeViewModel(services));
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<RegisterViewModel>>(services => () => services.GetRequiredService<RegisterViewModel>());

                services.AddSingleton<Renavigator<HomeViewModel>>();
                services.AddSingleton<Renavigator<LoginViewModel>>();
                services.AddSingleton<Renavigator<RegisterViewModel>>();
            });

            return host;
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(services.GetRequiredService<Renavigator<HomeViewModel>>(),
                                      services.GetRequiredService<Renavigator<RegisterViewModel>>(), 
                                      services.GetRequiredService<IAuthenticator>());
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel(services.GetRequiredService<IAuthenticator>(),
                                     services.GetRequiredService<Renavigator<LoginViewModel>>());
        }
    }
}
