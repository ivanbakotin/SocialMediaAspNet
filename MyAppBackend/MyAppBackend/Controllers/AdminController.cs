using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.PostService;
using System;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IPostService postService;
        public AdminController(IPostService postService)
        {
            this.postService = postService ?? throw new ArgumentNullException(nameof(postService));
        }

        [HttpDelete("user/{id}"), Authorize]
        public IActionResult RemoveUser()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("post/{id}"), Authorize]
        public IActionResult RemovePost(int id)
        {
            postService.DeletePost(1, id);
            return Ok();
        }

        [HttpDelete("comment/{id}"), Authorize]
        public IActionResult RemoveComment()
        {
            throw new NotImplementedException();
        }
    }
}
