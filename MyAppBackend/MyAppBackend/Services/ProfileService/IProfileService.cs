using MyAppBackend.Models;

namespace MyAppBackend.Services.ProfileService
{
    public interface IProfileService
    {
        Profile Get(int UserID);
        bool Update(Profile profile, int UserID);
        bool Delete(int UserID);
    }
}
