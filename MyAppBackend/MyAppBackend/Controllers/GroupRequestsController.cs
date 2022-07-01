using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.GroupRequestService;
using System;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupRequestsController : BaseController
    {
        private readonly IGroupRequestService groupRequestService;

        public GroupRequestsController(IGroupRequestService groupRequestService)
        {
            this.groupRequestService = groupRequestService ?? throw new ArgumentNullException(nameof(groupRequestService));
        }

        [HttpPost("send/{id}"), Authorize]
        public IActionResult SendGroupRequest(int id)
        {
            groupRequestService.SendGroupRequest(id, GetCurrentUserID());
            return Ok();
        }

        [HttpDelete("decline/{id}"), Authorize]
        public IActionResult DeclineGroupRequest(int id)
        {
            groupRequestService.DeclineGroupRequest(id, GetCurrentUserID());
            return Ok();
        }

        [HttpPost("invite/{id}"), Authorize]
        public IActionResult InviteToGroup(int id, [FromBody] int MemberID)
        {
            groupRequestService.InviteToGroup(id, GetCurrentUserID(), MemberID);
            return Ok();
        }

        [HttpPost("accept/{id}"), Authorize]
        public IActionResult AcceptToGroup(int id, [FromBody] int GroupID)
        {
            groupRequestService.AcceptToGroup(id, GetCurrentUserID(), GroupID);
            return Ok();
        }

        [HttpGet("requestssent/{id}"), Authorize]
        public IActionResult GetGroupRequestsSent(int id)
        {
            groupRequestService.GetGroupRequestsSent(GetCurrentUserID());
            return Ok();
        }

        [HttpGet("requestspending/{id}"), Authorize]
        public IActionResult GetGroupRequestsPending(int id)
        {
            groupRequestService.GetGroupRequestsPending(GetCurrentUserID());
            return Ok();
        }

        [HttpGet("userrequestssent"), Authorize]
        public IActionResult GetUserGroupRequestsSent()
        {
            groupRequestService.GetUserGroupRequestsSent(GetCurrentUserID());
            return Ok();
        }

        [HttpGet("userrequestspending"), Authorize]
        public IActionResult GetUserGroupRequestsPending()
        {
            groupRequestService.GetUserGroupRequestsPending(GetCurrentUserID());
            return Ok();
        }
    }
}
