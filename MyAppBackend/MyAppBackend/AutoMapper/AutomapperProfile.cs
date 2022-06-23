using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Linq;

namespace MyAppBackend.Profiles
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, PostViewModel>()
                .ForMember(x => x.Username, o => o.MapFrom(x => x.User.Username))
                .ForMember(x => x.CommentsNumber, o => o.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.Votes, o => o.MapFrom(x => x.Votes.Sum(v => v.Liked ? 1 : -1)));

            CreateMap<User, UserViewModel>();
        }
    }
}
