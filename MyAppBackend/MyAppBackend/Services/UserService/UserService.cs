using MyAppBackend.Models;
using MyAppBackend.Repositories;
using MyAppBackend.Utilities;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.UserService
{
    public class UserService : IUserService
    {

        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserViewModel>> SearchUsers(string param)
        {
            return await unitOfWork.Users.SearchUsers(param);
        }

        public async Task<User> GetCurrentUser(int UserID)
        {
            return await unitOfWork.Users.Find(x => x.ID == UserID);
        }

        public async Task<IEnumerable<UserViewModel>> GetRecommended(int UserID)
        {
            return await unitOfWork.Users.GetRecommended(UserID);
        }

        public void ResetPassword()
        {
            throw new NotImplementedException();
        }

        public void ChangePassword(string newPassword, User userObject)
        {
            userObject.Password = CustomHash.HashString(newPassword);
            unitOfWork.Save();
        }

        public async Task ChangeEmail(string newEmail, User userObject)
        {
            bool emailExists = await unitOfWork.Users.EmailExists(newEmail);
            if (!emailExists)
            {
                userObject.Email = newEmail;
                unitOfWork.Save();        
            }
        }

        public void DeleteUser(User userObject)
        {
            unitOfWork.Users.Remove(userObject);
            unitOfWork.Save();     
        }
    }
}
