using DataBase.Models;
using System.Windows.Input;
using WPFAuthenticationSample.Commands;
using WPFAuthenticationSample.Services.Authenticators;
using WPFAuthenticationSample.Services.Navigators;

namespace WPFAuthenticationSample.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private readonly IAuthenticator _authenticator;

        public HomeViewModel(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _authenticator.PropertyChanged += () => OnPropertyChanged(nameof(Account));
            LogoutCommand = new LogoutCommand(_authenticator, renavigator);
        }

        public ICommand LogoutCommand { get; }
        public Account Account => _authenticator.CurrentAccount;
    }
}
