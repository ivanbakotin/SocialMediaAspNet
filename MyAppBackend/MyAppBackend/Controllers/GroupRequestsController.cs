using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.ActionFilters;
using MyAppBackend.Services.GroupRequestService;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GroupRequestsController : BaseController
    {
        private readonly IGroupRequestService groupRequestService;

        public GroupRequestsController(IGroupRequestService groupRequestService)
        {
            this.groupRequestService = groupRequestService ?? throw new ArgumentNullException(nameof(groupRequestService));
        }

        [HttpPost("send/{id}")]
        public IActionResult SendGroupRequest(int id)
        {
            groupRequestService.SendGroupRequest(id, GetCurrentUserID());
            return Ok();
        }

        [HttpDelete("decline/{id}")]
        public async Task<IActionResult> DeclineGroupRequest(int id)
        {
            await groupRequestService.DeclineGroupRequest(id, GetCurrentUserID());
            return Ok();
        }

        [HttpPost("invite/{GroupID}")]
        [ServiceFilter(typeof(GroupOwnerAdminFilter))]
        public IActionResult InviteToGroup(int GroupID, [FromBody] int UserID)
        {
            groupRequestService.InviteToGroup(GroupID, UserID, GetCurrentUserID());
            return Ok();
        }

        [HttpPost("accept/{GroupID}")]
        public async Task<IActionResult> AcceptGroupInvitation(int GroupID)
        {
            await groupRequestService.AcceptInvitation(GetCurrentUserID(), GroupID);
            return Ok();
        }

        [HttpPost("accept/{GroupID}/{UserID}")]
        [ServiceFilter(typeof(GroupOwnerAdminFilter))]
        public async Task<IActionResult> AcceptRequest(int UserID, int GroupID)
        {
            await groupRequestService.AcceptRequest(UserID, GroupID);
            return Ok();
        }

        [HttpGet("requestssent/{GroupID}")]
        [ServiceFilter(typeof(GroupOwnerAdminFilter))]
        public async Task<IActionResult> GetGroupRequestsSent(int GroupID)
        {
            var result = await groupRequestService.GetGroupRequestsSent(GroupID);
            return Ok(result);
        }

        [HttpGet("requestspending/{GroupID}")]
        [ServiceFilter(typeof(GroupOwnerAdminFilter))]
        public async Task<IActionResult> GetGroupRequestsPending(int GroupID)
        {
            var result = await groupRequestService.GetGroupRequestsPending(GroupID);
            return Ok(result);
        }

        [HttpGet("userrequestssent")]
        public async Task<IActionResult> GetUserGroupRequestsSent()
        {
            var result = await groupRequestService.GetUserGroupRequestsSent(GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("userrequestspending")]
        public async Task<IActionResult> GetUserGroupRequestsPending()
        {
            var result = await groupRequestService.GetUserGroupRequestsPending(GetCurrentUserID());
            return Ok(result);
        }
    }
}
