using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.UserService
{
    public interface IUserService
    {
        public List<UserViewModel> SearchUsers(string param);
        public void ResetPassword();
        public void ChangePassword();
        public void ChangeEmail();
    }
}
