using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.UserService
{
    public interface IUserService
    {
        Task<List<UserViewModel>> SearchUsers(string param);
        Task<List<UserViewModel>> GetRecommended(int UserID);
        Task ResetPassword();
        Task ChangePassword(string confirmPassword, string newPassword, int UserID);
        Task ChangeEmail(string confirmPassword, string newEmail, int UserID);
        Task DeleteUser(string confirmPassword, int UserID);
    }
}
