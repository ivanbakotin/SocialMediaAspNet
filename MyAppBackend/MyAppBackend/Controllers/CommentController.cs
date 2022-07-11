using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Services.CommentService;
using MyAppBackend.ViewModels;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
        }

        [HttpGet("{id}"), Authorize]
        public async Task<IActionResult> GetComments(int id)
        {
            var comments = await commentService.GetComments(GetCurrentUserID(), id);
            return Ok(comments);
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
        {
            CommentViewModel createdComment = await commentService.CreateComment(comment, GetCurrentUserID());
            return Ok(createdComment);
        }

        [HttpPut("update/{id}"), Authorize]
        public async Task<IActionResult> UpdateComment([FromBody] Comment comment, int id)
        {
            await commentService.UpdateComment(comment, GetCurrentUserID(), id);
            return Ok();
        }

        [HttpDelete("delete/{id}"), Authorize]
        public async Task<IActionResult> DeleteComment(int id)
        {
            await commentService.DeleteComment(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpPost("vote/{id}"), Authorize]
        public async Task<IActionResult> VoteComment([FromBody] bool vote, int id)
        {
            await commentService.VoteComment(GetCurrentUserID(), id, vote);
            return Ok();
        }
    }
}
