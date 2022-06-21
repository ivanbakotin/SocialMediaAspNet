using AutoMapper;
using MyAppBackend.Data;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAppBackend.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public UserService(IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public List<UserViewModel> SearchUsers(string param)
        {
            // if string is ""
            var result = mapper.ProjectTo<UserViewModel>(from user in context.Users
                         where user.Username.Contains(param)
                         select user
                         ).ToList();

            return result;
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
