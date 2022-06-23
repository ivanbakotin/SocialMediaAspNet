using MyAppBackend.ViewModels;
using System.Collections.Generic;

namespace MyAppBackend.Services.UserService
{
    public interface IUserService
    {
        public List<UserViewModel> SearchUsers(string param);
        public void ResetPassword();
        public void ChangePassword();
        public void ChangeEmail();
        public void DeleteUser(int id);
    }
}
