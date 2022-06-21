using MyAppBackend.Data;
using MyAppBackend.ViewModels;
using System.Collections.Generic;

namespace MyAppBackend.Services.PostService
{
    public interface IPostService
    {
        List<PostViewModel> GetPosts(int UserID);
        PostViewModel GetPost(int UserID, int PostID);
        int UpdatePost(int UserID, int PostID);
        int DeletePost(int UserID, int PostID);
        bool UpvotePost(int UserID, int PostID);
        bool DownvotePost(int UserID, int PostID);
    }
}
