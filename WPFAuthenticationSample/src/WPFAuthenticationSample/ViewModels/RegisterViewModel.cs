using System.Windows.Input;
using WPFAuthenticationSample.Commands;
using WPFAuthenticationSample.Services.Authenticators;

namespace WPFAuthenticationSample.ViewModels
{
    class RegisterViewModel : ViewModelBase
    {
        public RegisterViewModel(IAuthenticator authenticator) 
        {
            RegisterCommand = new RegisterCommand(authenticator, this);
        }

        public ICommand RegisterCommand { get; }
        public bool CanRegister => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);

        private string _login;

        public string Login
        {
            get => _login;
            set
            {
                Set(ref _login, value);
                OnPropertyChanged(nameof(CanRegister));
            }
        }

        private string _password;

        public string Password
        {
            get => _password;
            set
            {
                Set(ref _password, value);
                OnPropertyChanged(nameof(CanRegister));
            }
        }
    }
}
