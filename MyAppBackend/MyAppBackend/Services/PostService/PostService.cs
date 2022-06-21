using MyAppBackend.Data;
using MyAppBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using MyAppBackend.ViewModels;
using AutoMapper;

namespace MyAppBackend.Services.PostService
{   
    public class PostService : IPostService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public PostService(IMapper mapper, DataContext context) 
        {
            this.mapper = mapper;
            this.context = context;
        }

        public List<PostViewModel> GetPosts(int UserID)
        {  
            var result = (from post in context.Posts
                          join user in context.Users
                          on post.UserID equals user.ID
                          where post.UserID == UserID || context.Friends.Any(friend => ((friend.UserID2 == UserID && friend.UserID1 == post.UserID)
                                                                                     || (friend.UserID1 == UserID && friend.UserID2 == post.UserID)))
                          select new PostViewModel
                          {
                              ID = post.ID,
                              Body = post.Body,
                              Title = post.Title,
                              CreatorID = post.UserID,
                              Creator = user.username,
                              Votes = post.Votes.Sum(v => v.Liked ? 1 : -1),
                              CommentsNumber = post.Comments.Count()
                          })
                          .ToList();

            return result;       
        }

        public PostViewModel GetPost(int UserID, int PostID)
        {
            var result = (from post in context.Posts
                          join user in context.Users
                          on post.UserID equals user.ID
                          where post.ID == PostID
                          select new PostViewModel
                          {
                              ID = post.ID,
                              CreatorID = post.UserID,
                              Body = post.Body,
                              Title = post.Title,
                              Creator = user.username,
                              Votes = post.Votes.Sum(v => v.Liked ? 1 : -1),
                              CommentsNumber = post.Comments.Count()
                          }).FirstOrDefault();

            return result;
        }

        public int UpdatePost(int UserID, int PostID)
        {
            throw new NotImplementedException();
        }

        public int DeletePost(int UserID, int PostID)
        {
            throw new NotImplementedException();
        }

        public bool UpvotePost(int UserID, int PostID)
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

        public bool DownvotePost(int UserID, int PostID)
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
