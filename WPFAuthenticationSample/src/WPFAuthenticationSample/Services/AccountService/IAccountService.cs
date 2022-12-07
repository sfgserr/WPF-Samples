using DataBase.Models;
using System.Threading.Tasks;

namespace WPFAuthenticationSample.Services.AccountService
{
    interface IAccountService
    {
        Task<Account> GetAccountByLogin(string login);
        Task AddAccount(string login, string password);
    }
}
