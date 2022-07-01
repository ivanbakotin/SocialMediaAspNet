using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Services.PostService
{
    public interface IPostService
    {
        Task<List<PostViewModel>> GetPosts(int UserID);
        Task<List<PostViewModel>> GetUserPosts(int UserID);
        Task<PostViewModel> GetPost(int UserID, int PostID);
        Task<PostViewModel> CreatePost(Post post, int UserID);
        Task UpdatePost(string body, int UserID, int PostID);
        Task DeletePost(int UserID, int PostID);
        Task VotePost(int UserID, int PostID, bool vote);
    }
}
