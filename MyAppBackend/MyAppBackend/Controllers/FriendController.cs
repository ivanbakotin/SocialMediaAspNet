using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.FriendService;
using System;

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
        public IActionResult GetAllRequestsPending()
        {
            var result = friendService.GetAllRequestsPending(GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("requestssent"), Authorize]
        public IActionResult GetAllRequestsSent()
        {
            var result = friendService.GetAllRequestsSent(GetCurrentUserID());
            return Ok(result);
        }

        [HttpGet("friends/{id}"), Authorize]
        public IActionResult GetAllFriends(int id)
        {
            var friends = friendService.GetAllFriends(id);
            return Ok(friends);
        }

        [HttpPost("send/{id}"), Authorize]
        public IActionResult SendFriendRequest(int id)
        {
            friendService.SendFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpDelete("remove/{id}"), Authorize]
        public IActionResult RemoveFriend(int id)
        {
            friendService.RemoveFriend(GetCurrentUserID(), id); 
            return Ok();
        }

        [HttpPost("accept/{id}"), Authorize]
        public IActionResult AcceptFriendRequest(int id)
        {
            friendService.AcceptFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }

        [HttpDelete("decline/{id}"), Authorize]
        public IActionResult RemoveFriendRequest(int id)
        {
            friendService.RemoveFriendRequest(GetCurrentUserID(), id);
            return Ok();
        }
    }
}
