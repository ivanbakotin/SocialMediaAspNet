using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.CommentService;
using MyAppBackend.Services.PostService;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Authorize(Roles="admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ICommentService commentService;
        private readonly IPostService postService;

        public AdminController(ICommentService commentService, IPostService postService)
        {
            this.commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
            this.postService = postService ?? throw new ArgumentNullException(nameof(postService));

        }

        [HttpDelete("post/{id}")]
        public async Task<IActionResult> RemovePost(int id)
        {
            await postService.DeletePost(id);
            return Ok();
        }

        [HttpDelete("comment/{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            await commentService.DeleteComment(id);
            return Ok();
        }
    }
}
