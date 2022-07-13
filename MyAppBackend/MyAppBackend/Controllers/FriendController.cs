using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.FriendService;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : BaseController
    {
        private readonly IFriendService friendService;

        public FriendController(IFriendService friendService)
        {
            this.friendService = friendService ?? throw new ArgumentNullException(nameof(friendService));
        }

        [HttpGet("requestspending")]
        public async Task<IActionResult> GetAllRequestsPending()
        {
            var result = await friendService.GetAllRequestsPending(GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("requestssent")]
        public async Task<IActionResult> GetAllRequestsSent()
        {
            var result = await friendService.GetAllRequestsSent(GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("friends/{id}")]
        public async Task<IActionResult> GetAllFriends(int id)
        {
            var friends = await friendService.GetAllFriends(id);
            return Ok(friends);
        }

        [HttpPost("send/{id}")]
        public IActionResult SendFriendRequest(int id)
        {
            friendService.SendFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveFriend(int id)
        {
            await friendService.RemoveFriend(GetCurrentUserID(), id); 
            return Ok();
        }

        [HttpPost("accept/{id}")]
        public async Task<IActionResult> AcceptFriendRequest(int id)
        {
            await friendService.AcceptFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpDelete("decline/{id}")]
        public async Task<IActionResult> RemoveFriendRequest(int id)
        {
            await friendService.RemoveFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }
    }
}
