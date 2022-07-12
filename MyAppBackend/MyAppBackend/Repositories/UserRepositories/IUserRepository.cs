using MyAppBackend.ApiModels;
using MyAppBackend.Models;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.UserRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> FindUser(LoginUser user);
        Task<bool> UserExists(User user);
    }
}
