using MyAppBackend.Data;
using MyAppBackend.Models;
using System.Linq;

namespace MyAppBackend.Services.ProfileService
{
    public class ProfileService
    {
        private readonly DataContext context;

        public ProfileService( DataContext context)
        {
            this.context = context;
        }

        public Profile Get(int UserID)
        {
            var result = context.Profiles.Where(p => p.userID == UserID).FirstOrDefault();
            return result;
        }

        public void Update(int UserID)
        {
            //write middleware
        }

        public void Delete(int UserID)
        {

            var deleteProfile = context.Profiles.Where(p => p.userID == UserID);
            context.Remove(deleteProfile);
            context.SaveChanges();
            
        }
    }
}
