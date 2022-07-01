using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAppBackend.Utilities;

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

        public async Task<List<UserViewModel>> SearchUsers(string param)
        {
            var result = await mapper.ProjectTo<UserViewModel>(from user in context.Users
                         where user.Username.Contains(param)
                         select user
                         ).ToListAsync();

            return result;
        }

        public async Task<List<UserViewModel>> GetRecommended(int UserID)
        {
            var result = await mapper.ProjectTo
                            <UserViewModel>(context.Users
                                .Where(x => x.ID != UserID && 
                                       !context.Friends.Any(f => (f.UserID2 == UserID )
                                                              || (f.UserID1 == UserID )))
                                .OrderByDescending(u => u.Posts.Count)
                                .Take(5))
                                .ToListAsync();

            return result;
        }

        public async Task ResetPassword()
        {
            throw new NotImplementedException();
        }

        public async Task ChangePassword(string confirmPassword, string newPassword, int UserID)
        {
            var user = await context.Users.Where(x => x.ID == UserID).FirstOrDefaultAsync();

            var hashedPassword = CustomHash.HashString(confirmPassword);

            if (hashedPassword == user.Password)
            {
                user.Password = hashedPassword;
                await context.SaveChangesAsync();
            }
        }

        public async Task ChangeEmail(string confirmPassword, string newEmail, int UserID)
        {
            var user = await context.Users.Where(x => x.ID == UserID).FirstOrDefaultAsync();

            var hashedPassword = CustomHash.HashString(confirmPassword);

            if (hashedPassword == user.Password)
            {
                user.Email = newEmail;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(string confirmPassword, int UserID)
        {
            var user = await context.Users.Where(x => x.ID == UserID).FirstOrDefaultAsync();

            var hashedPassword = CustomHash.HashString(confirmPassword);

            if (hashedPassword == user.Password)
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }
    }
}
