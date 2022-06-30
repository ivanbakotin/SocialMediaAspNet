using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Services.GroupService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService ?? throw new ArgumentNullException(nameof(groupService));
        }

        private int GetCurrentUserID()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userID = claims.Where(p => p.Type == "ID").FirstOrDefault()?.Value;
            return Int32.Parse(userID);
        }

        [HttpGet("search/{param}"), Authorize]
        public IActionResult SearchGroups(string param)
        {
            return Ok();
        }

        [HttpGet("searchusers/{id}/{param}"), Authorize]
        public IActionResult SearchGroupUsers(int id, string param)
        {
            return Ok();
        }

        [HttpGet("users/{id}"), Authorize]
        public IActionResult GetGroupUsers(int id)
        {    
            return Ok();
        }

        [HttpGet("posts/{id}"), Authorize]
        public IActionResult GetGroupPosts(int id)
        {     
            return Ok();
        }

        [HttpGet("info/{id}"), Authorize]
        public IActionResult GetGroupInfo(int id)
        {
            return Ok();
        }

        [HttpPut("info/{GroupID}"), Authorize]
        public IActionResult UpdateGroupInfo(Group body, int GroupID)
        {
            groupService.UpdateGroupInfo(body, GroupID);
            return Ok();
        }

        [HttpDelete("delete/{GroupID}"), Authorize]
        public IActionResult DeleteGroup(int GroupID)
        {
            groupService.DeleteGroup(GroupID);
            return Ok();
        }

        [HttpDelete("removeuser/{GroupID}"), Authorize]
        public IActionResult RemoveGroupUser([FromBody] int UserID, int GroupID)
        {
            groupService.RemoveGroupUser(UserID, GroupID);
            return Ok();
        }

        [HttpPost("create"), Authorize]
        public IActionResult CreateGroup(Group group)
        {
            var result = groupService.CreateGroup(group, GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("getusergroups"), Authorize]
        public IActionResult GetUserGroups()
        {
            var result = groupService.GetUserGroups(GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("recommended"), Authorize]
        public IActionResult GetRecommendedGroups()
        {
            return Ok();
        }
    }
}
