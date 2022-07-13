using AutoMapper;
using MyAppBackend.Models;
using MyAppBackend.Repositories;
using MyAppBackend.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppBackend.Services.PostService
{
    public class PostService : IPostService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public PostService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PostViewModel>> GetTimelinePosts(int UserID)
        {
            return await unitOfWork.Posts.GetTimelinePosts(UserID);
        }

        public async Task<IEnumerable<PostViewModel>> GetUserPosts(int UserID)
        {
            return await unitOfWork.Posts.GetUserPosts(UserID);
        }

        public async Task<PostViewModel> GetPost(int UserID, int PostID)
        {
            return await unitOfWork.Posts.GetPost(UserID, PostID);
        }

        public async Task<PostViewModel> CreatePost(Post post, int UserID)
        {
            var body = post.Body.Trim();
            int summarySize = 200 > body.Length ? body.Length : 200;
            post.Summary = body[..summarySize];
            post.PreHtmlBody = body;
            post.Body = ConvertBody(body);
            post.UserID = UserID;
            unitOfWork.Posts.Add(post);
            unitOfWork.Save();
            await CreatePostTags(post.ID, body);
            return mapper.Map<PostViewModel>(post);
        }

        public async Task UpdatePost(string body, int UserID, int PostID)
        {
            //remove post tags 
            //add post tags

            var postToUpdate = await unitOfWork.Posts.Get(PostID);

            if (postToUpdate != null)
            {
                postToUpdate.Body = body;
                unitOfWork.Save();
            }
        }

        public async Task DeletePost(int PostID)
        {
            var postToDelete = await unitOfWork.Posts.Get(PostID);

            if (postToDelete != null)
            {
                unitOfWork.Posts.Remove(postToDelete);
                unitOfWork.Save();
            }
        }

        public async Task VotePost(int UserID, int PostID, bool vote)
        {
            var votedPost = await unitOfWork.VotedPosts.Find(vp => vp.PostID == PostID && vp.UserID == UserID);

            if (votedPost == null)
            {
                VotedPost newVotedPost = new()
                {
                    UserID = UserID,
                    PostID = PostID,
                    Liked = vote
                };

                unitOfWork.VotedPosts.Add(newVotedPost);
            } 
            else if (votedPost.Liked != vote)
            {
                votedPost.Liked = vote;
            } 
            else
            {
                unitOfWork.VotedPosts.Remove(votedPost);
            }

            unitOfWork.Save();
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
                    unitOfWork.Tags.Add(newTag);
                }
            }

            unitOfWork.Save();
        }
    }
}
