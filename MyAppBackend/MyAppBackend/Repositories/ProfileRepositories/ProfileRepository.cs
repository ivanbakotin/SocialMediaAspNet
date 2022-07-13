using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.ProfileRepositories
{
    public class ProfileRepository : Repository<Models.Profile>, IProfileRepository
    {
        public ProfileRepository(DataContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<ProfileViewModel> GetProfile(int UserID, User user)
        {
            return await mapper.ProjectTo<ProfileViewModel>(
                                from p in context.Profiles
                                where p.UserID == user.ID
                                select p, new { CurrentUserID = UserID })
                                .FirstOrDefaultAsync();
        }
    }
}
