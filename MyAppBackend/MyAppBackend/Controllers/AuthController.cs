using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Data;
using MyAppBackend.Utilities;
using MyAppBackend.Services.Auth;
using System;

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

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var token = authService.Login(user);

            if (token == null)
            {
                return CustomHttp.HttpResponse("Wrong email or password", 409);
            } 

            return Ok(new AuthenticatedResponse { Token = token });                
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            bool flag = authService.Register(user);

            if (!flag)
            {
                return CustomHttp.HttpResponse("Email or username taken!", 409);
            }

            return Ok();               
        }
    }
}
