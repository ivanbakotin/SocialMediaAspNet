using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyAppBackend.Utilities;
using MyAppBackend.Models;

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
            return await mapper.ProjectTo<UserViewModel>(from user in context.Users
                         where user.Username.Contains(param)
                         select user
                         ).ToListAsync();
        }

        public async Task<User> GetCurrentUser(int UserID)
        {
            return await context.Users.Where(x => x.ID == UserID).FirstOrDefaultAsync();
        }

        public async Task<List<UserViewModel>> GetRecommended(int UserID)
        {
            return await mapper.ProjectTo
                            <UserViewModel>(context.Users
                                .Where(x => x.ID != UserID && 
                                       !context.Friends.Any(f => (f.UserID2 == UserID )
                                                              || (f.UserID1 == UserID )))
                                .OrderByDescending(u => u.Posts.Count)
                                .Take(5))
                                .ToListAsync();
        }

        public async Task ResetPassword()
        {
            throw new NotImplementedException();
        }

        public async Task ChangePassword(string newPassword, User userObject)
        {
            userObject.Password = CustomHash.HashString(newPassword);
            await context.SaveChangesAsync();
        }

        public async Task ChangeEmail(string newEmail, User userObject)
        {
            var emailExists = context.Users.Any(x => x.Email == newEmail);
            if (!emailExists)
            {
                userObject.Email = newEmail;
                await context.SaveChangesAsync();        
            }
        }

        public async Task DeleteUser(User userObject)
        {
            context.Users.Remove(userObject);
            await context.SaveChangesAsync();     
        }
    }
}
