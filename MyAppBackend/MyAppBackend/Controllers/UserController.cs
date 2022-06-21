using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        private int GetCurrentUserID()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userID = claims.Where(p => p.Type == "ID").FirstOrDefault()?.Value;
            return Int32.Parse(userID);
        }

        [HttpGet("search"), Authorize]
        public void SearchUsers()
        {

        }

        [HttpPut("resetpassword"), Authorize]
        public void ResetPassword()
        {

        }

        [HttpPut("changepassword"), Authorize]
        public void ChangePassword()
        {

        }

        [HttpPut("changeemail"), Authorize]
        public void ChangeEmail()
        {

        }
    }
}
