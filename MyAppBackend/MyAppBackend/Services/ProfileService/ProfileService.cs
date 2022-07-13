using MyAppBackend.Models;
using MyAppBackend.Repositories;
using MyAppBackend.ViewModels;
using System.Threading.Tasks;

namespace MyAppBackend.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly IUnitOfWork unitOfWork;

        public ProfileService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<ProfileViewModel> Get(string username, int UserID)
        {
            User user = await unitOfWork.Users.Find(x => x.Username == username);
            return await unitOfWork.Profiles.GetProfile(UserID, user);
        }

        public void Update(Profile profile)
        {
            unitOfWork.Profiles.Update(profile);
            unitOfWork.Save();      
        }
    }
}
