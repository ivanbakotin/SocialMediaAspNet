using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Repositories.PostRepositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<IEnumerable<PostViewModel>> GetTimelinePosts(int UserID);
        Task<IEnumerable<PostViewModel>> GetUserPosts(int UserID);
        Task<PostViewModel> GetPost(int UserID, int PostID);
    }
}
