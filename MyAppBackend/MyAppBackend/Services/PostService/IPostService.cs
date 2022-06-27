﻿using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;

namespace MyAppBackend.Services.PostService
{
    public interface IPostService
    {
        List<PostViewModel> GetPosts(int UserID);
        List<PostViewModel> GetUserPosts(int UserID);
        PostViewModel GetPost(int UserID, int PostID);
        PostViewModel CreatePost(Post post, int UserID);
        bool UpdatePost(string body, int UserID, int PostID);
        bool DeletePost(int UserID, int PostID);
        void VotePost(int UserID, int PostID, bool vote);
    }
}
