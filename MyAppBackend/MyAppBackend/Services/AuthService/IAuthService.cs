using MyAppBackend.Models;

namespace MyAppBackend.Services.Auth
{
    public interface IAuthService
    {
        string Login(User user);
        bool Register(User user);
    }
}
