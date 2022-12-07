using DataBase.Models;
using System.Threading.Tasks;

namespace WPFAuthenticationSample.Services.AuthenticationService
{
    interface IAuthenticationService
    {
        Task<Account> Login(string login, string password);

        Task Register(string login, string password);
    }
}
