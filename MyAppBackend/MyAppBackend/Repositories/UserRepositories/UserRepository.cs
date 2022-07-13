using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.ApiModels;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
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

        public async Task<bool> EmailExists(string email)
        {
            return await context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<UserViewModel>> GetRecommended(int UserID)
        {
            return await mapper.ProjectTo
                            <UserViewModel>(context.Users
                                .Where(x => x.ID != UserID &&
                                       !context.Friends.Any(f => (f.UserID2 == UserID)
                                                              || (f.UserID1 == UserID)))
                                .OrderByDescending(u => u.Posts.Count)
                                .Take(5))
                                .ToListAsync();
        }

        public async Task<IEnumerable<UserViewModel>> SearchUsers(string param)
        {
            return await mapper.ProjectTo<UserViewModel>(from user in context.Users
                                                         where user.Username.Contains(param)
                                                         select user
                         ).ToListAsync();
        }

    }
}
