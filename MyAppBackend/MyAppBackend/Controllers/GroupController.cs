using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.ActionFilters;
using MyAppBackend.Models;
using MyAppBackend.Services.GroupService;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : BaseController
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
        }

        [HttpGet("search/{param}"), Authorize]
        public async Task<IActionResult> SearchGroups(string param)
        {
            await groupService.SearchGroups(param);
            return Ok();
        }

        [HttpGet("searchusers/{GroupID}/{param}"), Authorize]
        public async Task<IActionResult> SearchGroupUsers(int GroupID, string param)
        {
            await groupService.SearchGroupUsers(GroupID, param);
            return Ok();
        }

        [HttpGet("users/{GroupID}"), Authorize]
        public async Task<IActionResult> GetGroupUsers(int GroupID)
        {
            await groupService.GetGroupUsers(GroupID);
            return Ok();
        }

        [HttpGet("posts/{GroupID}"), Authorize]
        public async Task<IActionResult> GetGroupPosts(int GroupID)
        {
            await groupService.GetGroupPosts(GroupID);
            return Ok();
        }

        [HttpGet("info/{GroupID}"), Authorize]
        public async Task<IActionResult> GetGroupInfo(int GroupID)
        {
            await groupService.GetGroupInfo(GroupID);
            return Ok();
        }

        [HttpPut("info/{GroupID}"), Authorize]
        [ServiceFilter(typeof(GroupOwnerAdminFilter))]
        public async Task<IActionResult> UpdateGroupInfo(Group body, int GroupID)
        {
            await groupService.UpdateGroupInfo(body, GroupID, GetCurrentUserID());
            return Ok();
        }

        [HttpDelete("{GroupID}"), Authorize]
        [ServiceFilter(typeof(GroupOwnerFilter))]
        public async Task<IActionResult> DeleteGroup(int GroupID)
        {
            await groupService.DeleteGroup(GroupID, GetCurrentUserID());
            return Ok();
        }

        [HttpDelete("removeuser/{GroupID}"), Authorize]
        [ServiceFilter(typeof(GroupOwnerAdminFilter))]
        public async Task<IActionResult> RemoveGroupUser([FromBody] int UserID, int GroupID)
        {
            await groupService.RemoveGroupUser(UserID, GroupID);
            return Ok();
        }

        [HttpPost("create"), Authorize]
        public async Task<IActionResult> CreateGroup(Group group)
        {
            var result = await groupService.CreateGroup(group, GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("getusergroups"), Authorize]
        public async Task<IActionResult> GetUserGroups()
        {
            var result = await groupService.GetUserGroups(GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("recommended"), Authorize]
        public IActionResult GetRecommendedGroups()
        {
            return Ok();
        }
    }
}
