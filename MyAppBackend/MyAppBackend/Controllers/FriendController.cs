using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.FriendService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        private readonly IFriendService friendService;

        public FriendController(IFriendService friendService)
        {
            this.friendService = friendService ?? throw new ArgumentNullException(nameof(friendService));
        }

        private int GetCurrentUserID()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userID = claims.Where(p => p.Type == "ID").FirstOrDefault()?.Value;
            return Int32.Parse(userID);
        }

        [HttpPost("send/{id}"), Authorize]
        public void SendFriendRequest(int id)
        {

        }

        [HttpDelete("remove/{id}"), Authorize]
        public void RemoveFriend(int id)
        {

        }

        [HttpPost("accept/{id}"), Authorize]
        public void AcceptFriendRequest(int id)
        {

        }

        [HttpDelete("decline/{id}"), Authorize]
        public void RemoveFriendRequest(int id)
        {

        }
    }
}
