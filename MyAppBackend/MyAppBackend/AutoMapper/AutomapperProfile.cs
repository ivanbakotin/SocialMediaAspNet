using MyAppBackend.AutoMapperModels;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Linq;

namespace MyAppBackend.Profiles
{
    public class AutomapperProfile : AutoMapper.Profile
    {
        public AutomapperProfile()
        {
            CreateMap<PostUser, PostViewModel>()
                .ForMember(x => x.ID, o => o.MapFrom(x => x.Post.ID))
                .ForMember(x => x.CreatorID, o => o.MapFrom(x => x.User.ID))
                .ForMember(x => x.Body, o => o.MapFrom(x => x.Post.Body))
                .ForMember(x => x.Title, o => o.MapFrom(x => x.Post.Title))
                .ForMember(x => x.Creator, o => o.MapFrom(x => x.User.username))
                .ForMember(x => x.CommentsNumber, o => o.MapFrom(x => x.Post.Comments.Count))
                .ForMember(x => x.Votes, o => o.MapFrom(x => x.Post.Votes.Sum(v => v.Liked ? 1 : -1)));

            CreateMap<User, UserViewModel>();
        }
    }
}
