using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.GroupRequestService;
using System;
using System.Threading.Tasks;

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
        public async Task<IActionResult> SendGroupRequest(int id)
        {
            await groupRequestService.SendGroupRequest(id, GetCurrentUserID());
            return Ok();
        }

        [HttpDelete("decline/{id}"), Authorize]
        public async Task<IActionResult> DeclineGroupRequest(int id)
        {
            await groupRequestService.DeclineGroupRequest(id, GetCurrentUserID());
            return Ok();
        }

        [HttpPost("invite/{id}"), Authorize]
        public async Task<IActionResult> InviteToGroup(int id, [FromBody] int MemberID)
        {
            await groupRequestService.InviteToGroup(id, GetCurrentUserID(), MemberID);
            return Ok();
        }

        [HttpPost("accept/{id}"), Authorize]
        public async Task<IActionResult> AcceptToGroup(int id, [FromBody] int GroupID)
        {
            await groupRequestService.AcceptToGroup(id, GetCurrentUserID(), GroupID);
            return Ok();
        }

        [HttpGet("requestssent/{id}"), Authorize]
        public async Task<IActionResult> GetGroupRequestsSent(int id)
        {
            await groupRequestService.GetGroupRequestsSent(GetCurrentUserID());
            return Ok();
        }

        [HttpGet("requestspending/{id}"), Authorize]
        public async Task<IActionResult> GetGroupRequestsPending(int id)
        {
            await groupRequestService.GetGroupRequestsPending(GetCurrentUserID());
            return Ok();
        }

        [HttpGet("userrequestssent"), Authorize]
        public async Task<IActionResult> GetUserGroupRequestsSent()
        {
            await groupRequestService.GetUserGroupRequestsSent(GetCurrentUserID());
            return Ok();
        }

        [HttpGet("userrequestspending"), Authorize]
        public async Task<IActionResult> GetUserGroupRequestsPending()
        {
            await groupRequestService.GetUserGroupRequestsPending(GetCurrentUserID());
            return Ok();
        }
    }
}
