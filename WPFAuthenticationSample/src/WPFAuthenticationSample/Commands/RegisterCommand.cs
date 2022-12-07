using System;
using System.ComponentModel;
using System.Windows.Input;
using WPFAuthenticationSample.Services.Authenticators;
using WPFAuthenticationSample.ViewModels;

namespace WPFAuthenticationSample.Commands
{
    class RegisterCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        private readonly IAuthenticator _authenticator;
        private readonly RegisterViewModel _registerViewModel;

        public RegisterCommand(IAuthenticator authenticator, RegisterViewModel registerViewModel)
        {
            _authenticator = authenticator;
            _registerViewModel = registerViewModel;

            _registerViewModel.PropertyChanged += CanRegisterChanged;
        }

        public bool CanExecute(object? parameter)
        {
            return _registerViewModel.CanRegister;
        }

        public async void Execute(object? parameter)
        {
            await _authenticator.Register(_registerViewModel.Login, _registerViewModel.Password);
        }

        private void CanRegisterChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(_registerViewModel.CanRegister)) CanExecuteChanged?.Invoke(sender, e);
        }
    }
}
