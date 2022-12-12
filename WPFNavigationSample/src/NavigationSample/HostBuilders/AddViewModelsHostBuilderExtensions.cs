using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NavigationSample.ViewModels;
using NavigationSample.ViewModels.Factories;

namespace NavigationSample.HostBuilders
{
    static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            return host.ConfigureServices((context, services) =>
            {
                services.AddScoped<FirstViewModel>();
                services.AddScoped<SecondViewModel>();
                services.AddScoped<ThirdViewModel>();
                services.AddScoped<FourthViewModel>();
                services.AddScoped<MainViewModel>();

                services.AddSingleton<IFactoryViewModel, FactoryViewModel>();

                services.AddSingleton<CreateViewModel<FirstViewModel>>(services => () => services.GetRequiredService<FirstViewModel>());
                services.AddSingleton<CreateViewModel<SecondViewModel>>(services => () => services.GetRequiredService<SecondViewModel>());
                services.AddSingleton<CreateViewModel<ThirdViewModel>>(services => () => services.GetRequiredService<ThirdViewModel>());
                services.AddSingleton<CreateViewModel<FourthViewModel>>(services => () => services.GetRequiredService<FourthViewModel>());
            });
        }
    }
}
