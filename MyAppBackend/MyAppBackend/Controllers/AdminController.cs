using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        [HttpDelete("user/{id}"), Authorize]
        public IActionResult RemoveUser()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("post/{id}"), Authorize]
        public IActionResult RemovePost()
        {
            throw new NotImplementedException();
        }

        [HttpDelete("comment/{id}"), Authorize]
        public IActionResult RemoveComment()
        {
            throw new NotImplementedException();
        }
    }
}
