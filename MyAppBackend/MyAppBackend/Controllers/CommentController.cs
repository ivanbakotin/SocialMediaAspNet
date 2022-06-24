using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Services.CommentService;
using MyAppBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService ?? throw new ArgumentNullException(nameof(commentService));
        }
        private int GetCurrentUserID()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userID = claims.Where(p => p.Type == "ID").FirstOrDefault()?.Value;
            return Int32.Parse(userID);
        }

        [HttpGet("{id}"), Authorize]
        public IActionResult GetComments(int id)
        {
            List<CommentViewModel> comments = commentService.GetComments(GetCurrentUserID(), id);
            return Ok(comments);
        }

        [HttpGet("comment/{id}"), Authorize]
        public IActionResult GetComment(int id)
        {
            // get one comment 
            List<CommentViewModel> comments = commentService.GetComments(GetCurrentUserID(), id);
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
            bool flag = commentService.UpdateComment(comment, GetCurrentUserID(), id);
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
            //CommentViewModel comment = commentService.GetComment(GetCurrentUserID(), id);
            return Ok();
        }
    }
}
