using MyAppBackend.Data;

namespace MyAppBackend.Services.PostService
{
    public interface IPostService
    {
        dynamic GetPosts(DataContext context, int UserID);
        PostModel GetPost(DataContext context, int UserID, int PostID);
        int UpdatePost(DataContext context, int UserID, int PostID);
        int DeletePost(DataContext context, int UserID, int PostID);
        bool UpvotePost(DataContext context, int UserID, int PostID);
        bool DownvotePost(DataContext context, int UserID, int PostID);
    }
}
