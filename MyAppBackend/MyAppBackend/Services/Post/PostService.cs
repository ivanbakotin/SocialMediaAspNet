using MyAppBackend.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAppBackend.Services.Post
{   //DTO
    public class PostModel
    {
        public string Body { get; set; }
        public int UserID { get; set; }
        public string Title { get; set; }
        public string Creator { get; set; }
    }
    public class PostService : IPostService
    {
        public List<PostModel> GetPosts(DataContext context, int UserID)
        {
            var query = (from post in context.Posts
                         join u in context.Users
                         on post.UserID equals u.ID where context.Friends.Any(friend => (friend.UserID2 == UserID && friend.UserID1 == post.UserID
                                                            || friend.UserID1 == UserID && friend.UserID2 == post.UserID))
                         select new PostModel
                         {
                             Body = post.Body,
                             UserID = post.UserID,
                             Title = post.Title,
                             Creator = u.email
                         }).ToList();

            //var query = (from post in context.Posts
            //     
            //            where context.Friends.Any(friend => (friend.UserID2 == UserID && friend.UserID1 == post.UserID
            //                                               || friend.UserID1 == UserID && friend.UserID2 == post.UserID))
            //            select new PostModel
            //            {
            //                Body = post.Body,
            //                UserID = post.UserID,
            //                Title = post.Title,
            //                Creator = "Creator",
            //            }).ToList();

            return query;
        }

        public int GetPost(DataContext context)
        {
            throw new NotImplementedException();
        }
    }
}
