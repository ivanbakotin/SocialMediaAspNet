using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.ProfileRepositories
{
    public interface IProfileRepository : IRepository<Profile>
    {
        Task<ProfileViewModel> GetProfile(int UserID, User user);
    }
}
