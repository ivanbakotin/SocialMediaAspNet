using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Linq;

namespace MyAppBackend.Profiles
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            int CurrentUserID = 1;
            CreateMap<Post, PostViewModel>()
                .ForMember(x => x.Username, o => o.MapFrom(x => x.User.Username))
                .ForMember(x => x.CommentsNumber, o => o.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.Votes, o => o.MapFrom(x => x.Votes.Sum(v => v.Liked ? 1 : -1)))
                .ForMember(x => x.Voted, o => o.MapFrom(x => x.Votes.First(u => u.UserID == CurrentUserID).Liked));


            CreateMap<User, UserViewModel>();
        }
    }
}
