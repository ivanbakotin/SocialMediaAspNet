using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Data;
using MyAppBackend.Services.PostService;
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
        private readonly DataContext context;
        private readonly IPostService postService;
        public PostController(DataContext context, IPostService postService)
        {
            this.context = context;
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
        public dynamic GetPosts()
        {
            var posts = postService.GetPosts(context, GetCurrentUserID());
            return posts;
        }

        [HttpGet("post"), Authorize]
        public PostModel GetPost(int PostID)
        {
            var post = postService.GetPost(context, GetCurrentUserID(), PostID);
            return post;
        }

        [HttpGet("update"), Authorize]
        public IActionResult UpdatePost()
        {
            return Ok();
        }

        [HttpGet("delete"), Authorize]
        public IActionResult DeletePost()
        {
            return Ok();
        }

        [HttpGet("upvote"), Authorize]
        public IActionResult UpvotePost()
        {
            return Ok();
        }

        [HttpGet("downvote"), Authorize]
        public IActionResult Downvote()
        {
            return Ok();
        }
    }
}
