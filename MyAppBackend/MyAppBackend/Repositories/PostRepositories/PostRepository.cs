using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.PostRepositories
{
    public class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DataContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<IEnumerable<PostViewModel>> GetTimelinePosts(int UserID)
        {
            return await mapper.ProjectTo<PostViewModel>(
                                from post in context.Posts
                                where post.GroupID == null && post.UserID == UserID ||
                                       context.Friends.Any(f => (f.UserID2 == UserID && f.UserID1 == post.UserID)
                                                             || (f.UserID1 == UserID && f.UserID2 == post.UserID))
                                orderby post.ID descending
                                select post, new
                                {
                                    CurrentUserID = UserID
                                })
                                .ToListAsync();
        }

        public async Task<IEnumerable<PostViewModel>> GetUserPosts(int UserID)
        {
            return await mapper.ProjectTo<PostViewModel>(
                               from post in context.Posts
                               where post.GroupID == null && post.UserID == UserID
                               orderby post.ID descending
                               select post, new
                               {
                                   CurrentUserID = UserID
                               })
                               .ToListAsync();
        }

        public async Task<PostViewModel> GetPost(int UserID, int PostID)
        {
            return await mapper.ProjectTo<PostViewModel>(
                          from post in context.Posts
                          where post.ID == PostID
                          select post, new { CurrentUserID = UserID })
                          .FirstOrDefaultAsync();
        }
    }
}
