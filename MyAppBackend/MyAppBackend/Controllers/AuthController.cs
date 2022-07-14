using Microsoft.AspNetCore.Mvc;
using MyAppBackend.ActionFilters;
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
        [ServiceFilter(typeof(ModelValidationFilter))]
        public async Task<IActionResult> Login([FromBody] LoginUser user)
        {
            var response = await authService.Login(user);
            return Ok(response);
        }

        [HttpPost("register")]
        [ServiceFilter(typeof(ModelValidationFilter))]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            await authService.Register(user);
            return Ok();
        }

        [HttpPost("isloggedin")]
        public async Task<IActionResult> IsLoggedIn([FromBody] string jwt)
        {
            var response = await authService.IsLoggedIn(jwt);

            if (response == null)
            {
                return Ok();
            }

            return Created("Jwt", response);
        }

        [HttpDelete("logout")]
        public async Task<IActionResult> Logout()
        {
            await authService.Logout(GetCurrentUserID());
            return Ok();
        }
    }
}
