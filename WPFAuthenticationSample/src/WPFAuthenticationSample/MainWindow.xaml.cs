using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WPFAuthenticationSample.HostBuilders;
using WPFAuthenticationSample.Services.Navigators;
using WPFAuthenticationSample.ViewModels;

namespace WPFAuthenticationSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IHost _host;

        public MainWindow()
        {
            _host = CreateHostBuilder().Build();
            DataContext = _host.Services.GetRequiredService<MainViewModel>();
            InitializeComponent();
        }

        private IHostBuilder CreateHostBuilder(string[] args = null)
        {
            return Host.CreateDefaultBuilder(args)
                       .AddServices()
                       .AddViewModels();
        }
    }
}
