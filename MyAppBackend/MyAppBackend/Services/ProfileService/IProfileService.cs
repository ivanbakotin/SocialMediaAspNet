using MyAppBackend.Models;
using MyAppBackend.ViewModels;

namespace MyAppBackend.Services.ProfileService
{
    public interface IProfileService
    {
        ProfileViewModel Get(int UserID);
        bool Update(Profile profile, int UserID);
    }
}
