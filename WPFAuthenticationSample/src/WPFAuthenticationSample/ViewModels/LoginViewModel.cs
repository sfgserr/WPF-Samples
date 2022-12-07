using System.Windows.Input;
using WPFAuthenticationSample.Commands;
using WPFAuthenticationSample.Services.Authenticators;
using WPFAuthenticationSample.Services.Navigators;

namespace WPFAuthenticationSample.ViewModels
{
    class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(IRenavigator homeRenavigator, IRenavigator registerRenavigator, IAuthenticator authenticator)
        {
            LoginCommand = new LoginCommand(this, homeRenavigator, authenticator);
            NavigateCommand = new NavigateCommand(registerRenavigator);
        }

        public ICommand LoginCommand { get; }
        public ICommand NavigateCommand { get; }
        public bool CanLogin => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);

        private string _login;

        public string Login
        {
            get => _login;
            set 
            {
                Set(ref _login, value);
                OnPropertyChanged(nameof(CanLogin));
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                Set(ref _password, value);
                OnPropertyChanged(nameof(CanLogin));
            }
        }
    }
}
