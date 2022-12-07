using DataBase.Models;
using System;
using System.Threading.Tasks;

namespace WPFAuthenticationSample.Services.Authenticators
{
    interface IAuthenticator
    {
        Task Login(string login, string password);

        Task Register(string login, string password);

        Task Logout();

        event Action PropertyChanged;

        Account CurrentAccount { get; }
    }
}
