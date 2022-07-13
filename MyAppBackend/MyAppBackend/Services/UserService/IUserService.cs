using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.UserService
{
    public interface IUserService
    {
        Task<User> GetCurrentUser(int UserID);
        Task<IEnumerable<UserViewModel>> SearchUsers(string param);
        Task<IEnumerable<UserViewModel>> GetRecommended(int UserID);
        void ResetPassword();
        void ChangePassword(string newPassword, User userObject);
        Task ChangeEmail(string newEmail, User userObject);
        void DeleteUser(User userObject);
    }
}
