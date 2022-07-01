using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Services.CommentService;
using MyAppBackend.ViewModels;
using System;

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
        public IActionResult GetComments(int id)
        {
            var comments = commentService.GetComments(GetCurrentUserID(), id);
            return Ok(comments);
        }

        [HttpGet("comment/{id}"), Authorize]
        public IActionResult GetComment(int id)
        {
            // get one comment 
            var comments = commentService.GetComments(GetCurrentUserID(), id);
            return Ok(comments);
        }

        [HttpPost, Authorize]
        public IActionResult CreateComment([FromBody] Comment comment)
        {
            CommentViewModel createdComment = commentService.CreateComment(comment, GetCurrentUserID());
            return Ok(createdComment);
        }

        [HttpPut("update/{id}"), Authorize]
        public IActionResult UpdateComment([FromBody] Comment comment, int id)
        {
            commentService.UpdateComment(comment, GetCurrentUserID(), id);
            return Ok();
        }

        [HttpDelete("delete/{id}"), Authorize]
        public IActionResult DeleteComment(int id)
        {
            commentService.DeleteComment(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpPost("vote/{id}"), Authorize]
        public IActionResult VoteComment([FromBody] bool vote, int id)
        {
            commentService.VoteComment(GetCurrentUserID(), id, vote);
            return Ok();
        }
    }
}
