using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        [HttpGet, Authorize]
        public IActionResult GetProfile([FromBody] User user)
        {
            return Ok();
        }

        [HttpPut, Authorize]
        public IActionResult UpdateProfile([FromBody] Profile profile)
        {
            return Ok();
        }

        [HttpDelete, Authorize]
        public IActionResult DeleteProfile([FromBody] Profile profile)
        {
            return Ok();
        }
    }
}
