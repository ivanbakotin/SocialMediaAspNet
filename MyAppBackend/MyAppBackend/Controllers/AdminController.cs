using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Authorize(Roles="admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpDelete("post/{id}")]
        public async Task<IActionResult> RemovePost(int id)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("comment/{id}")]
        public async Task<IActionResult> RemoveComment(int id)
        {
            throw new NotImplementedException();
        }
    }
}
