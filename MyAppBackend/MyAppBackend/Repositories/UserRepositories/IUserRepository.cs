using MyAppBackend.ApiModels;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.UserRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindUser(LoginUser user);
        Task<bool> UserExists(User user);
        Task<bool> EmailExists(string email);
        Task<IEnumerable<UserViewModel>> GetRecommended(int UserID);
        Task<IEnumerable<UserViewModel>> SearchUsers(string param);
    }
}
