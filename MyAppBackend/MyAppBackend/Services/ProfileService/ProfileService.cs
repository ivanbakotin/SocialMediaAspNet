using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Linq;

namespace MyAppBackend.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly AutoMapper.IMapper mapper;
        private readonly DataContext context;

        public ProfileService(AutoMapper.IMapper mapper, DataContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public ProfileViewModel Get(int UserID, int id)
        {
            var result = mapper.ProjectTo<ProfileViewModel>(
                                from p in context.Profiles
                                where p.UserID == UserID
                                select p, new { CurrentUserID = id })
                                .FirstOrDefault();
            return result;
        }

        public bool Update(Profile profile, int UserID)
        {
            var profileToUpdate = context.Profiles.Where(p => p.UserID == UserID).FirstOrDefault();

            if (profileToUpdate != null)
            {
                profileToUpdate.Bio = profile.Bio;
                profileToUpdate.Age = profile.Age;
                profileToUpdate.Gender = profile.Gender;
                profileToUpdate.Birthday = profile.Birthday;
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
