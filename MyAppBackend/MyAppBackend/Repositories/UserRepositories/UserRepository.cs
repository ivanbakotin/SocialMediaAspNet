using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.ApiModels;
using MyAppBackend.Data;
using MyAppBackend.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.UserRepositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<User> FindUser(LoginUser user)
        {
            return await context.Users.Include(x => x.Role).Where(x => x.Email == user.Email).FirstOrDefaultAsync();
        }

        public async Task<bool> UserExists(User user)
        {
            return await context.Users.AnyAsync(u => u.Email == user.Email || u.Username == user.Username);
        }
    }
}
