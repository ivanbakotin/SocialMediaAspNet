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
            return await mapper.ProjectTo<PostViewModel>(
                                from post in context.Posts
                                where  post.GroupID == null && post.UserID == UserID ||
                                      context.Friends.Any(f => (f.UserID2 == UserID && f.UserID1 == post.UserID)
                                                             || (f.UserID1 == UserID && f.UserID2 == post.UserID))
                                orderby post.ID descending
                                select post, new { CurrentUserID = UserID })
                                .ToListAsync();
        }

        public async Task<List<PostViewModel>> GetUserPosts(int UserID)
        {
            return await mapper.ProjectTo<PostViewModel>(
                                from post in context.Posts
                                where post.GroupID == null && post.UserID == UserID
                                orderby post.ID descending
                                select post, new { CurrentUserID = UserID })
                                .ToListAsync();
        }

        public async Task<PostViewModel> GetPost(int UserID, int PostID)
        {
            return await mapper.ProjectTo<PostViewModel>(
                          from post in context.Posts
                          where post.ID == PostID
                          select post, new { CurrentUserID = UserID })
                          .FirstOrDefaultAsync();
        }

        public async Task<PostViewModel> CreatePost(Post post, int UserID)
        {
            var body = post.Body.Trim();
            post.Summary = body[..200];
            post.PreHtmlBody = body;
            post.Body = ConvertBody(body);
            post.UserID = UserID;
            await context.Posts.AddAsync(post);
            await context.SaveChangesAsync();
            await CreatePostTags(post.ID, body);
            return mapper.Map<PostViewModel>(post);
        }

        public async Task UpdatePost(string body, int UserID, int PostID)
        {
            //remove post tags 
            //add post tags

            var postToUpdate = await context.Posts.Where(p => p.ID == PostID).FirstOrDefaultAsync();

            if (postToUpdate != null)
            {
                postToUpdate.Body = body;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeletePost(int PostID)
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
            } 
            else
            {
                context.VotedPosts.Remove(votedPost);
            }

            await context.SaveChangesAsync();
        }    

        private static string ConvertBody(string body)
        {
            return string.Join(" ", body.Split(" ").Select(x =>
            {
                if (x[0] == '#')
                {
                    return $"<mark>{x}</mark>";
                }

                if (x[0] == '@')
                {
                    return $"<a href='profile/{x[1..]}'>{x}</a>";
                }

                return x;
            }));
        }

        private async Task CreatePostTags(int postID, string body)
        {
            foreach (string word in body.Split(" "))
            {
                if (word[0] == '#')
                {
                    Tag newTag = new() { Name = word, PostID = postID };
                    await context.Tags.AddAsync(newTag);
                }
            }

            await context.SaveChangesAsync();
        }
    }
}
