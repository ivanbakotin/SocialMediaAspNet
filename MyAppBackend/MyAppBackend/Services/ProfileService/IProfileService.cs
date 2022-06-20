using MyAppBackend.Data;
using MyAppBackend.Services.PostService;
using System.Collections.Generic;

namespace MyAppBackend.Services.ProfileService
{
    public interface IProfileService
    {
        dynamic Get(DataContext context, int UserID);
        void Update(DataContext context, int MyID, int UserID);
        void Delete(DataContext context, int MyID, int UserID);
    }
}
