using MyAppBackend.Data;
using System.Linq;

namespace MyAppBackend.Services.ProfileService
{
    public class ProfileService
    {
        public dynamic Get(DataContext context, int UserID)
        {
            var result = context.Profiles.Where(p => p.userID == UserID).FirstOrDefault();
            return result;
        }

        public void Update(DataContext context, int MyID, int UserID)
        {
            //write middleware
            if ( MyID == UserID)
            {
                
            }
        }

        public void Delete(DataContext context, int MyID, int UserID)
        {
            if (MyID == UserID)
            {
                var deleteProfile = context.Profiles.Where(p => p.userID == UserID);
                context.Remove(deleteProfile);
                context.SaveChanges();
            }
        }
    }
}
