using MyAppBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.UserService
{
    public class UserService :IUserService
    {
        private readonly DataContext context;

        public UserService(DataContext context)
        {
            this.context = context;
        }

        public void SearchUsers()
        {
            throw new NotImplementedException();
        }
        public void ResetPassword()
        {
            throw new NotImplementedException();
        }
        public void ChangePassword()
        {
            throw new NotImplementedException();
        }
        public void ChangeEmail()
        {
            throw new NotImplementedException();
        }
    }
}
