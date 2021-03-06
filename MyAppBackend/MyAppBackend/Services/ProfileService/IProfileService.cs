using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Threading.Tasks;

namespace MyAppBackend.Services.ProfileService
{
    public interface IProfileService
    {
        Task<ProfileViewModel> Get(string username, int UserID);
        void Update(Profile profile);
    }
}
