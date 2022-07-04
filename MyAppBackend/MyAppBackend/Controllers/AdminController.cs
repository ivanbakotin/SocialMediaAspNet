using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.PostService;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> RemoveUser()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("post/{id}"), Authorize]
        public async Task<IActionResult> RemovePost(int id)
        {

            throw new NotImplementedException();
        }

        [HttpDelete("comment/{id}"), Authorize]
        public async Task<IActionResult> RemoveComment()
        {
            throw new NotImplementedException();
        }
    }
}
