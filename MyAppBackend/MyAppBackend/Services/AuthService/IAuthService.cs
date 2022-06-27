using MyAppBackend.ApiModels;
using MyAppBackend.Models;

namespace MyAppBackend.Services.Auth
{
    public interface IAuthService
    {
        string Login(LoginUser user);
        bool Register(User user);
        string IsLoggedIn(string token);
        void Logout(int UserID);
    }
}
