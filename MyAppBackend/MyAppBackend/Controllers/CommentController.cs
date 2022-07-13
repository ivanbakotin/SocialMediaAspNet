using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Services.CommentService;
using MyAppBackend.ViewModels;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : BaseController
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
        }

        [HttpGet("{PostID}")]
        public async Task<IActionResult> GetComments(int PostID)
        {
            var comments = await commentService.GetComments(GetCurrentUserID(), PostID);
            return Ok(comments);
        }

        [HttpPost]
        public IActionResult CreateComment([FromBody] Comment comment)
        {
            CommentViewModel createdComment = commentService.CreateComment(comment, GetCurrentUserID());
            return Ok(createdComment);
        }

        [HttpPut("update/{CommentID}")]
        public async Task<IActionResult> UpdateComment([FromBody] Comment comment, int CommentID)
        {
            await commentService.UpdateComment(comment, CommentID);
            return Ok();
        }

        [HttpDelete("delete/{CommentID}")]
        public async Task<IActionResult> DeleteComment(int CommentID)
        {
            await commentService.DeleteComment(CommentID);
            return Ok();
        }

        [HttpPost("vote/{CommentID}")]
        public async Task<IActionResult> VoteComment([FromBody] bool vote, int CommentID)
        {
            await commentService.VoteComment(GetCurrentUserID(), CommentID, vote);
            return Ok();
        }
    }
}
