using MyAppBackend.Models;
using MyAppBackend.Settings;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.PostService
{
    public interface IPostService
    {
        Task<IEnumerable<PostViewModel>> GetTimelinePosts(int UserID, PostPagination postPagination);
        Task<IEnumerable<PostViewModel>> GetUserPosts(int UserID);
        Task<PostViewModel> GetPost(int UserID, int PostID);
        PostViewModel CreatePost(Post post, int UserID);
        Task UpdatePost(string body, int UserID, int PostID);
        Task DeletePost(int PostID);
        Task VotePost(int UserID, int PostID, bool vote);
    }
}
