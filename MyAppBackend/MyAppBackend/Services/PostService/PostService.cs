using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAppBackend.Data;
using MyAppBackend.Models;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IMapper mapper;
        private readonly DataContext context;

        public PostService(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<PostViewModel>> GetPosts(int UserID)
        {
            var result = await mapper.ProjectTo<PostViewModel>(
                                from post in context.Posts
                                where  post.GroupID == null && post.UserID == UserID ||
                                      context.Friends.Any(f => (f.UserID2 == UserID && f.UserID1 == post.UserID)
                                                             || (f.UserID1 == UserID && f.UserID2 == post.UserID))
                                orderby post.ID descending
                                select post, new { CurrentUserID = UserID })
                                .ToListAsync();

            return result;
        }

        public async Task<List<PostViewModel>> GetUserPosts(int UserID)
        { 
            var result = await mapper.ProjectTo<PostViewModel>(
                                from post in context.Posts
                                where post.UserID == UserID
                                orderby post.ID descending
                                select post, new { CurrentUserID = UserID })
                                .ToListAsync();

            return result;
        }

        public async Task<PostViewModel> GetPost(int UserID, int PostID)
        {
            var result = await mapper.ProjectTo<PostViewModel>(
                          from post in context.Posts
                          where post.ID == PostID
                          select post, new { CurrentUserID = UserID })
                          .FirstOrDefaultAsync();

            return result;
        }

        public async Task<PostViewModel> CreatePost(Post post, int UserID)
        {
            post.UserID = UserID;
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();

            PostViewModel createdPost = mapper.Map<PostViewModel>(post);
         
            return createdPost;
        }

        public async Task UpdatePost(string body, int UserID, int PostID)
        {
            var postToUpdate = await context.Posts.Where(p => p.ID == PostID).FirstOrDefaultAsync();

            if (postToUpdate != null)
            {
                postToUpdate.Body = body;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeletePost(int UserID, int PostID)
        {
            var postToDelete = await context.Posts.Where(p => p.ID == PostID).FirstOrDefaultAsync();

            if (postToDelete != null)
            {
                context.Posts.Remove(postToDelete);
                await context.SaveChangesAsync();
            }
        }

        public async Task VotePost(int UserID, int PostID, bool vote)
        {
            var votedPost = await context.VotedPosts.Where(vp => vp.PostID == PostID && vp.UserID == UserID).FirstOrDefaultAsync();

            if (votedPost == null)
            {
                VotedPost newVotedPost = new()
                {
                    UserID = UserID,
                    PostID = PostID,
                    Liked = vote
                };

                await context.VotedPosts.AddAsync(newVotedPost);
            }
            else if (votedPost.Liked != vote)
            {
                votedPost.Liked = vote;
            } else
            {
                context.VotedPosts.Remove(votedPost);
            }

            await context.SaveChangesAsync();
        }    
    }
}
