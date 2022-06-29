using MyAppBackend.ViewModels;
using System.Collections.Generic;

namespace MyAppBackend.Services.UserService
{
    public interface IUserService
    {
        List<UserViewModel> SearchUsers(string param);
        List<UserViewModel> GetRecommended(int UserID);
        void ResetPassword();
        void ChangePassword();
        void ChangeEmail();
        void DeleteUser(int id);
    }
}
