using DataBase.Models;
using System;
using System.Threading.Tasks;
using WPFAuthenticationSample.Services.AuthenticationService;

namespace WPFAuthenticationSample.Services.Authenticators
{
    class Authenticator : IAuthenticator
    {
        public event Action PropertyChanged;

        private readonly IAuthenticationService _authenticationService;

        public Authenticator(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private Account _currentAccount;

        public Account CurrentAccount
        {
            get => _currentAccount;
            private set
            {
                _currentAccount= value;
                PropertyChanged?.Invoke();
            }
        }


        public async Task Login(string login, string password)
        {
            CurrentAccount = await _authenticationService.Login(login, password);
        }

        public async Task Logout()
        {
            await Task.Run(() => CurrentAccount = null);
        }

        public async Task Register(string login, string password)
        {
            await _authenticationService.Register(login, password);
        }
    }
}
