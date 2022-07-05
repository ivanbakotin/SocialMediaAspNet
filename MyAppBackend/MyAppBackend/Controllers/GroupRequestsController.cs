using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.ActionFilters;
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

        [HttpPost("invite/{GroupID}"), Authorize]
        [ServiceFilter(typeof(GroupOwnerAdminFilter))]
        public async Task<IActionResult> InviteToGroup(int GroupID, [FromBody] int UserID)
        {
            await groupRequestService.InviteToGroup(GroupID, UserID, GetCurrentUserID());
            return Ok();
        }

        [HttpPost("accept/{GroupID}"), Authorize]
        public async Task<IActionResult> AcceptGroupInvitation(int GroupID)
        {
            await groupRequestService.AcceptInvitation(GetCurrentUserID(), GroupID);
            return Ok();
        }

        [HttpPost("accept/{GroupID}/{UserID}"), Authorize]
        [ServiceFilter(typeof(GroupOwnerAdminFilter))]
        public async Task<IActionResult> AcceptRequest(int UserID, int GroupID)
        {
            await groupRequestService.AcceptRequest(UserID, GroupID);
            return Ok();
        }

        [HttpGet("requestssent/{GroupID}"), Authorize]
        [ServiceFilter(typeof(GroupOwnerAdminFilter))]
        public async Task<IActionResult> GetGroupRequestsSent(int GroupID)
        {
            var result = await groupRequestService.GetGroupRequestsSent(GroupID);
            return Ok(result);
        }

        [HttpGet("requestspending/{GroupID}"), Authorize]
        [ServiceFilter(typeof(GroupOwnerAdminFilter))]
        public async Task<IActionResult> GetGroupRequestsPending(int GroupID)
        {
            var result = await groupRequestService.GetGroupRequestsPending(GroupID);
            return Ok(result);
        }

        [HttpGet("userrequestssent"), Authorize]
        public async Task<IActionResult> GetUserGroupRequestsSent()
        {
            var result = await groupRequestService.GetUserGroupRequestsSent(GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("userrequestspending"), Authorize]
        public async Task<IActionResult> GetUserGroupRequestsPending()
        {
            var result = await groupRequestService.GetUserGroupRequestsPending(GetCurrentUserID());
            return Ok(result);
        }
    }
}
