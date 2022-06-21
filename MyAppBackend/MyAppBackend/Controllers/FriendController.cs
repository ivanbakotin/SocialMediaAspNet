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

        [HttpPost("send"), Authorize]
        public void SendFriendRequest()
        {

        }

        [HttpDelete("remove"), Authorize]
        public void RemoveFriend()
        {

        }

        [HttpPost("accept"), Authorize]
        public void AcceptFriendRequest()
        {

        }

        [HttpDelete("decline"), Authorize]
        public void DeclineFriendRequest()
        {

        }
    }
}
