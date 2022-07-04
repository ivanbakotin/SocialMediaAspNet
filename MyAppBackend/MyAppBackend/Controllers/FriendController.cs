using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.FriendService;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : BaseController
    {
        private readonly IFriendService friendService;

        public FriendController(IFriendService friendService)
        {
            this.friendService = friendService ?? throw new ArgumentNullException(nameof(friendService));
        }

        [HttpGet("requestspending"), Authorize]
        public async Task<IActionResult> GetAllRequestsPending()
        {
            var result = await friendService.GetAllRequestsPending(GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("requestssent"), Authorize]
        public async Task<IActionResult> GetAllRequestsSent()
        {
            var result = await friendService.GetAllRequestsSent(GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("friends/{id}"), Authorize]
        public async Task<IActionResult> GetAllFriends(int id)
        {
            var friends = await friendService.GetAllFriends(id);
            return Ok(friends);
        }

        [HttpPost("send/{id}"), Authorize]
        public async Task<IActionResult> SendFriendRequest(int id)
        {
            await friendService.SendFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpDelete("remove/{id}"), Authorize]
        public async Task<IActionResult> RemoveFriend(int id)
        {
            await friendService.RemoveFriend(GetCurrentUserID(), id); 
            return Ok();
        }

        [HttpPost("accept/{id}"), Authorize]
        public async Task<IActionResult> AcceptFriendRequest(int id)
        {
            await friendService.AcceptFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpDelete("decline/{id}"), Authorize]
        public async Task<IActionResult> RemoveFriendRequest(int id)
        {
            await friendService.RemoveFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }
    }
}
