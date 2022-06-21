using MyAppBackend.Data;
using MyAppBackend.Models;
using System.Linq;

namespace MyAppBackend.Services.ProfileService
{
    public class ProfileService : IProfileService
    {
        private readonly DataContext context;

        public ProfileService( DataContext context)
        {
            this.context = context;
        }

        public Profile Get(int UserID)
        {
            var result = context.Profiles.Where(p => p.UserID == UserID).FirstOrDefault();
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

        public bool Delete(int UserID)
        {
            var deleteProfile = context.Profiles.Where(p => p.UserID == UserID);

            if (deleteProfile == null)
            {
                context.Remove(deleteProfile);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
