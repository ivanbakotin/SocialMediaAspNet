using MyAppBackend.Models;
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
        Task ChangePassword(string newPassword, User userObject);
        Task ChangeEmail(string newEmail, User userObject);
        Task DeleteUser(User userObject);
    }
}
