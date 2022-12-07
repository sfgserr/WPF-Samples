using DataBase.Models;
using System;
using System.Threading.Tasks;
using WPFAuthenticationSample.Services.AccountService;

namespace WPFAuthenticationSample.Services.AuthenticationService
{
    class AuthenticationService : IAuthenticationService
    {
        private readonly IAccountService _accountService;

        public AuthenticationService(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public async Task<Account> Login(string login, string password)
        {
            Account storedAccount = await _accountService.GetAccountByLogin(login);

            if (storedAccount is null)
                throw new Exception();

            if (storedAccount.Password != password)
                throw new Exception();

            return storedAccount;
        }

        public async Task Register(string login, string password)
        {
            Account storedAccount = await _accountService.GetAccountByLogin(login);
            if (storedAccount is null) await _accountService.AddAccount(login, password);  
        }
    }
}
