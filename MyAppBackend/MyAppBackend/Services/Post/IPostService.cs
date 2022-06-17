using MyAppBackend.Data;
using System.Collections.Generic;

namespace MyAppBackend.Services.Post
{
    public interface IPostService
    {
        List<PostModel> GetPosts(DataContext context, int UserID);
        int GetPost(DataContext context);
    }
}
