using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.FriendService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
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

        [HttpGet("send"), Authorize]
        public void SendFriendRequest()
        {

        }

        [HttpGet("remove"), Authorize]
        public void RemoveFriend()
        {

        }

        [HttpGet("accept"), Authorize]
        public void AcceptFriendRequest()
        {

        }

        [HttpGet("decline"), Authorize]
        public void DeclineFriendRequest()
        {

        }
    }
}
