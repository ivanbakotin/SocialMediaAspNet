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
        private readonly DataContext context;

        private readonly IAuthService authService;

        public AuthController(DataContext context, IAuthService authService)
        {
            this.context = context;
            this.authService = authService ?? throw new ArgumentNullException(nameof(authService));
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var token = authService.Login(user, context);

            if (token == null)
            {
                return CustomHttp.HttpResponse("Wrong email or password", 409);
            } 

            return Ok(new AuthenticatedResponse { Token = token });                
        }

        [HttpPost("register")]
        public Task Register([FromBody] User user) => authService.Register(user, context);
    }
}
