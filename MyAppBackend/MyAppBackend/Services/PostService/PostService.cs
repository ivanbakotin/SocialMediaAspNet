using MyAppBackend.Data;
using MyAppBackend.Models;
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
            var result = mapper.ProjectTo<PostViewModel>(
                                from post in context.Posts
                                where post.UserID == UserID ||
                                      context.Friends.Any(f => ((f.UserID2 == UserID && f.UserID1 == post.UserID)
                                                             || (f.UserID1 == UserID && f.UserID2 == post.UserID)))
                                select post, new { CurrentUserID = UserID })
                                .ToList();

            return result;
        }

        public PostViewModel GetPost(int UserID, int PostID)
        {
            var result = mapper.ProjectTo<PostViewModel>(
                          from post in context.Posts
                          where post.ID == PostID
                          select post, new { CurrentUserID = UserID })
                          .FirstOrDefault();

            return result;
        }

        public PostViewModel CreatePost(Post post, int UserID)
        {
            post.UserID = UserID;
            context.Posts.Add(post);
            context.SaveChanges();

            PostViewModel createdPost = mapper.Map<PostViewModel>(post);
         
            return createdPost;
        }

        public bool UpdatePost(Post post, int UserID, int PostID)
        {
            var postToUpdate = context.Posts.Where(p => p.ID == PostID).FirstOrDefault();

            if (postToUpdate != null)
            {
                postToUpdate.Body = post.Body;
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeletePost(int UserID, int PostID)
        {
            var postToDelete = context.Posts.Where(p => p.ID == PostID).FirstOrDefault();

            if (postToDelete != null)
            {
                context.Posts.Remove(postToDelete);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        public void VotePost(int UserID, int PostID, bool vote)
        {
            var votedPost = context.VotedPosts.Where(vp => vp.PostID == PostID && vp.UserID == UserID).FirstOrDefault();

            if (votedPost == null)
            {
                VotedPost newVotedPost = new VotedPost
                {
                    UserID = UserID,
                    PostID = PostID,
                    Liked = vote
                };

                context.VotedPosts.Add(newVotedPost);
            }
            else if (votedPost.Liked != vote)
            {
                votedPost.Liked = vote;
            } else
            {
                context.VotedPosts.Remove(votedPost);
            }

            context.SaveChanges();
        }    
    }
}