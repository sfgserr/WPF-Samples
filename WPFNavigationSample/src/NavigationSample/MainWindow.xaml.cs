using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NavigationSample.HostBuilders;
using NavigationSample.ViewModels;
using System.Windows;

namespace NavigationSample
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
                       .AddNavigators()
                       .AddViewModels();
        }
    }
}
