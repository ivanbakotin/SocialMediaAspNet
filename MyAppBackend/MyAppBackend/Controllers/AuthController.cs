using Microsoft.AspNetCore.Mvc;
using MyAppBackend.ApiModels;
using MyAppBackend.Models;
using MyAppBackend.Services.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        private int GetCurrentUserID()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userID = claims.Where(p => p.Type == "ID").FirstOrDefault()?.Value;
            return Int32.Parse(userID);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUser user)
        {
            var token = authService.Login(user);

            if (token == null)
            {
                return StatusCode(409, "Wrong email or password");
            }

            return Ok(new AuthenticatedResponse { Token = token });
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            bool flag = authService.Register(user);

            if (!flag)
            {
                return StatusCode(409, "Email or username taken!");
            }

            return Ok();
        }

        [HttpPost("isloggedin")]
        public IActionResult IsLoggedIn([FromBody] string jwt)
        {
            var token = authService.IsLoggedIn(jwt);

            if (token == null)
            {
                return Ok();
            }

            return Ok(new AuthenticatedResponse { Token = token });
        }

        [HttpDelete("logout")]
        public IActionResult Logout()
        {
            authService.Logout(GetCurrentUserID());
            return Ok();
        }
    }
}
