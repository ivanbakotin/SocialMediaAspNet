using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Threading.Tasks;

namespace MyAppBackend.Services.ProfileService
{
    public interface IProfileService
    {
        Task<ProfileViewModel> Get(int UserID, int id);
        Task Update(Profile profile, int UserID);
    }
}
