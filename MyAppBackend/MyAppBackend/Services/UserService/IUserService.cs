using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.UserService
{
    public interface IUserService
    {
        public void SearchUsers();
        public void ResetPasswordEmail();
        public void ChangePassword();
        public void ChangeEmail();
    }
}
