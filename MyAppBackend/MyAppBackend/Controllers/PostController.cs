using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.PostService;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService ?? throw new ArgumentNullException(nameof(postService));
        }
        private int GetCurrentUserID()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userID = claims.Where(p => p.Type == "ID").FirstOrDefault()?.Value;
            return Int32.Parse(userID);
        }

        [HttpGet("posts"), Authorize]
        public List<PostViewModel> GetPosts()
        {
            var posts = postService.GetPosts(GetCurrentUserID());
            return posts;
        }

        [HttpGet("post"), Authorize]
        public PostViewModel GetPost(int PostID)
        {
            var post = postService.GetPost(GetCurrentUserID(), PostID);
            return post;
        }

        [HttpGet("update"), Authorize]
        public IActionResult UpdatePost(int PostID)
        {
            postService.UpdatePost(GetCurrentUserID(), PostID);
            return Ok();
        }

        [HttpGet("delete"), Authorize]
        public IActionResult DeletePost(int PostID)
        {
            postService.DeletePost(GetCurrentUserID(), PostID);
            return Ok();
        }

        [HttpGet("upvote"), Authorize]
        public IActionResult UpvotePost(int PostID)
        {
            postService.UpvotePost(GetCurrentUserID(), PostID);
            return Ok();
        }

        [HttpGet("downvote"), Authorize]
        public IActionResult Downvote(int PostID)
        {
            postService.DownvotePost(GetCurrentUserID(), PostID);
            return Ok();
        }
    }
}
