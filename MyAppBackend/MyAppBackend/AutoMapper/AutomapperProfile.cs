using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Linq;

namespace MyAppBackend.Profiles
{
    public class AutomapperProfile : AutoMapper.Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.User.Username))
                .ForMember(x => x.CommentsNumber, o => o.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.Votes, o => o.MapFrom(x => x.Votes.Sum(v => v.Liked ? 1 : -1)));

            CreateMap<User, UserViewModel>();
        }
    }
}
