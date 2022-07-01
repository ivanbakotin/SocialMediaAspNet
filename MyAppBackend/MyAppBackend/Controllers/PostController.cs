using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Services.PostService;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : BaseController
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService ?? throw new ArgumentNullException(nameof(postService));
        }

        [HttpGet, Authorize]
        public async Task<IActionResult> GetPosts()
        {
            var posts = await postService.GetPosts(GetCurrentUserID());
            return Ok(posts);
        }

        [HttpGet("posts/{id}"), Authorize]
        public async Task<IActionResult> GetUserPosts(int id)
        {
            List<PostViewModel> posts = await postService.GetUserPosts(id);
            return Ok(posts);
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetPost(int id)
        {
            PostViewModel post = await postService.GetPost(GetCurrentUserID(), id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            PostViewModel createdPost = await postService.CreatePost(post, GetCurrentUserID());
            return Ok(createdPost);
        }

        [HttpPut("update/{id}"), Authorize]
        public async Task<IActionResult> UpdatePost([FromBody] string body, int id)
        {
            await postService.UpdatePost(body, GetCurrentUserID(), id);
            return Ok();
        }

        [HttpDelete("delete/{id}"), Authorize]
        public async Task<IActionResult> DeletePost(int id)
        {
            await postService.DeletePost(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpPost("vote/{id}"), Authorize]
        public async Task<IActionResult> VotePost([FromBody] bool vote, int id)
        {
            await postService.VotePost(GetCurrentUserID(), id, vote);
            return Ok();
        }
    }
}
