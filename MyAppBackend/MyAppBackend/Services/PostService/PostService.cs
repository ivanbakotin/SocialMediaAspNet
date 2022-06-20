using MyAppBackend.Data;
using MyAppBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyAppBackend.Services.PostService
{   
    public class PostModel
    {
        public int ID { get; set; }
        public int CreatorID { get; set; }
        public string Creator { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Votes { get; set; }
        public int Comments { get; set; }
    }

    public class PostService : IPostService
    {
        public dynamic GetPosts(DataContext context, int UserID)
        {  
            var result = (from post in context.Posts
                          join user in context.Users
                          on post.UserID equals user.ID
                          where post.UserID == UserID || context.Friends.Any(friend => ((friend.UserID2 == UserID && friend.UserID1 == post.UserID)
                                                                                     || (friend.UserID1 == UserID && friend.UserID2 == post.UserID)))
                          select new PostModel
                          {
                              ID = post.ID,
                              Body = post.Body,
                              Title = post.Title,
                              CreatorID = post.UserID,
                              Creator = user.username,
                              Votes = post.Votes.Sum(v => v.Liked ? 1 : -1),
                              Comments = post.Comments.Count()
                          }).ToList();

            return result;       
        }

        public PostModel GetPost(DataContext context, int UserID, int PostID)
        {
            var result = (from post in context.Posts
                          join user in context.Users
                          on post.UserID equals user.ID
                          where post.ID == PostID
                          select new PostModel
                          {
                              ID = post.ID,
                              CreatorID = post.UserID,
                              Body = post.Body,
                              Title = post.Title,
                              Creator = user.username,
                              Votes = post.Votes.Sum(v => v.Liked ? 1 : -1),
                              Comments = post.Comments.Count()
                          }).FirstOrDefault();

            return result;
        }

        public int UpdatePost(DataContext context, int UserID, int PostID)
        {
            throw new NotImplementedException();
        }

        public int DeletePost(DataContext context, int UserID, int PostID)
        {
            throw new NotImplementedException();
        }

        public bool UpvotePost(DataContext context, int UserID, int PostID)
        {
            var votedPost = context.VotedPosts.Where(vp => vp.PostID == PostID && vp.UserID == UserID).FirstOrDefault();

            if (votedPost == null)
            {
                VotedPost newVotedPost = new VotedPost
                {
                    UserID = UserID,
                    PostID = PostID,
                    Liked = true
                };

                context.VotedPosts.Add(newVotedPost);
            } else
            {
                context.VotedPosts.Remove(votedPost);
            }

            context.SaveChanges();

            return true;
        }

        public bool DownvotePost(DataContext context, int UserID, int PostID)
        {
            var votedPost = context.VotedPosts.Where(vp => vp.PostID == PostID && vp.UserID == UserID).FirstOrDefault();

            if (votedPost == null)
            {
                VotedPost newVotedPost = new VotedPost
                {
                    UserID = UserID,
                    PostID = PostID,
                    Liked = false
                };

                context.VotedPosts.Add(newVotedPost);
            }
            else
            {
                context.VotedPosts.Remove(votedPost);
            }

            context.SaveChanges();

            return true;
        }
    }
}
