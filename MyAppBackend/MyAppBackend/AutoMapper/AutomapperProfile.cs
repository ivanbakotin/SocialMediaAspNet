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

            CreateMap<Profile, ProfileViewModel>()
                .ForMember(x => x.Username, o => o.MapFrom(x => x.User.Username))
                .ForMember(x => x.Email, o => o.MapFrom(x => x.User.Email))
                .ForMember(x => x.IsFriend, o => o.MapFrom(x => x.User.Friends1.Any(f => f.UserID1 == CurrentUserID || f.UserID2 == CurrentUserID) 
                                                             || x.User.Friends2.Any(f => f.UserID1 == CurrentUserID || f.UserID2 == CurrentUserID)))
                .ForMember(x => x.IsRequesting, o => o.MapFrom(x => x.User.FriendRequestsMe.Any(f => f.UserID == CurrentUserID)))
                .ForMember(x => x.IAmRequesting, o => o.MapFrom(x => x.User.FriendRequestsThem.Any(f => f.FollowerID == CurrentUserID)));

            CreateMap<User, RequestViewModel>()
                .ForMember(x => x.Username, o => o.MapFrom(x => x.FriendRequestsThem));

            CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.Username, o => o.MapFrom(x => x.User.Username))
                .ForMember(x => x.CommentsNumber, o => o.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.Votes, o => o.MapFrom(x => x.Votes.Sum(v => v.Liked ? 1 : -1)))
                .ForMember(x => x.Voted, o => o.MapFrom(x => x.Votes.First(u => u.UserID == CurrentUserID).Liked));
        }
    }
}
