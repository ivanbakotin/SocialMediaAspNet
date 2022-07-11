using MyAppBackend.ApiModels;
using MyAppBackend.Models;
using System.Threading.Tasks;

namespace MyAppBackend.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthenticatedResponse> Login(LoginUser user);
        Task<bool> Register(User user);
        Task<AuthenticatedResponse> IsLoggedIn(string token);
        Task Logout(int UserID);
    }
}
