using DataBase.Models;
using System;
using System.ComponentModel;
using System.Windows.Input;
using WPFAuthenticationSample.Services.Authenticators;
using WPFAuthenticationSample.Services.Navigators;
using WPFAuthenticationSample.ViewModels;

namespace WPFAuthenticationSample.Commands
{
    class LoginCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly LoginViewModel _loginViewModel;
        private readonly IRenavigator _renavitor;
        private readonly IAuthenticator _authenticator;

        public LoginCommand(LoginViewModel loginViewModel, IRenavigator renavitor, IAuthenticator authenticator)
        {
            _loginViewModel = loginViewModel;
            _renavitor = renavitor;
            _authenticator = authenticator;

            _loginViewModel.PropertyChanged += CanLoginChanged;
        }

        public bool CanExecute(object? parameter)
        {
            return _loginViewModel.CanLogin;
        }

        public async void Execute(object? parameter)
        {
             await _authenticator.Login(_loginViewModel.Login, _loginViewModel.Password);
            _renavitor.Navigate();
        }

        private void CanLoginChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_loginViewModel.CanLogin)) CanExecuteChanged?.Invoke(sender, e);
        }
    }
}
