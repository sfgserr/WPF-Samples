using System;
using System.Windows.Input;
using WPFAuthenticationSample.Services.Authenticators;
using WPFAuthenticationSample.Services.Navigators;

namespace WPFAuthenticationSample.Commands
{
    class LogoutCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly IAuthenticator _authenticator;
        private readonly IRenavigator _renavigator;

        public LogoutCommand(IAuthenticator authenticator, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _renavigator = renavigator;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public async void Execute(object? parameter)
        {
            await _authenticator.Logout();
            _renavigator.Navigate();
        }
    }
}
