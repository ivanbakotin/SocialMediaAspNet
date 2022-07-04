using Microsoft.AspNetCore.Mvc;
using MyAppBackend.ApiModels;
using MyAppBackend.Models;
using MyAppBackend.Services.Auth;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUser user)
        {
            var token = await authService.Login(user);

            if (token == null)
            {
                return StatusCode(409, "Wrong email or password");
            }

            return Ok(new AuthenticatedResponse { Token = token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            bool flag = await authService.Register(user);

            if (!flag)
            {
                return StatusCode(409, "Email or username taken!");
            }

            return Ok();
        }

        [HttpPost("isloggedin")]
        public async Task<IActionResult> IsLoggedIn([FromBody] string jwt)
        {
            var token = await authService.IsLoggedIn(jwt);

            if (token == null)
            {
                return Ok();
            }

            return Ok(new AuthenticatedResponse { Token = token });
        }

        [HttpDelete("logout")]
        public async Task<IActionResult> Logout()
        {
            await authService.Logout(GetCurrentUserID());
            return Ok();
        }
    }
}
