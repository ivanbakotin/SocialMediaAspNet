using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupRequestsController : ControllerBase
    {
        private int GetCurrentUserID()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userID = claims.Where(p => p.Type == "ID").FirstOrDefault()?.Value;
            return Int32.Parse(userID);
        }

        [HttpPost("send/{id}"), Authorize]
        public IActionResult SendGroupRequest(int id)
        {
            return Ok();
        }

        [HttpDelete("decline/{id}"), Authorize]
        public IActionResult DeclineGroupRequest(int id)
        {
            return Ok();
        }

        [HttpDelete("removerequest/{id}"), Authorize]
        public IActionResult RemoveGroupRequest(int id)
        {
            return Ok();
        }

        [HttpPost("invite/{id}"), Authorize]
        public IActionResult InviteToGroup(int id)
        {
            return Ok();
        }

        [HttpPost("accept/{id}"), Authorize]
        public IActionResult AcceptToGroup(int id)
        {
            return Ok();
        }

        [HttpGet("requestssent/{id}"), Authorize]
        public IActionResult GetGroupRequestsSent(int id)
        {
            return Ok();
        }

        [HttpGet("requestspending/{id}"), Authorize]
        public IActionResult GetGroupRequestsPending(int id)
        {
            return Ok();
        }
    }
}
