using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.Services.PostService;
using System.Collections.Generic;

namespace MyAppBackend.Services.ProfileService
{
    public interface IProfileService
    {
        Profile Get(int UserID);
        void Update(Profile profile, int UserID);
        void Delete(int UserID);
    }
}
