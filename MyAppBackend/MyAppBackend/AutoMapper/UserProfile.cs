using MyAppBackend.Models;
using MyAppBackend.ViewModels;

namespace MyAppBackend.Profiles
{
    public class UserProfile : AutoMapper.Profile
    {
        public UserProfile()
        {
            CreateMap<Post, PostViewModel>();
        }
    }
}
