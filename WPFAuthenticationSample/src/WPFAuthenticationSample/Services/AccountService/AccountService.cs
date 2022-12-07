using DataBase;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace WPFAuthenticationSample.Services.AccountService
{
    class AccountService : IAccountService
    {
        public async Task<Account> GetAccountByLogin(string login)
        {
            using (AccountDataContext context = new AccountDataContext())
            {
                return await context.Accounts.FirstOrDefaultAsync(a => a.Login == login);
            }
        }

        public async Task AddAccount(string login, string password)
        {
            using(AccountDataContext context = new AccountDataContext())
            {
                Account account = new Account()
                {
                    Login = login,
                    Password = password
                };

                await context.Accounts.AddAsync(account);
                context.SaveChanges();
            }
        }
    }
}
