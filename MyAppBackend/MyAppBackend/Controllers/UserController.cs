using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Services.UserService;
using System;

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

        [HttpGet("search"), Authorize]
        public void SearchUsers()
        {

        }

        [HttpGet("posts"), Authorize]
        public void ResetPassword()
        {

        }

        [HttpGet("changepassword"), Authorize]
        public void ChangePassword()
        {

        }

        [HttpGet("changeemail"), Authorize]
        public void ChangeEmail()
        {

        }
    }
}
