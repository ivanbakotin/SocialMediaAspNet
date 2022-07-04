using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.ActionFilters;
using MyAppBackend.Models;
using MyAppBackend.Services.UserService;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("search/{param}")]
        public async Task<IActionResult> SearchUsers(string param)
        {
            var result = await userService.SearchUsers(param);
            return Ok(result);
        }

        [HttpGet("recommended")]
        public async Task<IActionResult> GetRecommended()
        {
            var result = await userService.GetRecommended(GetCurrentUserID());
            return Ok(result);
        }

        [HttpPut("resetpassword"), Authorize]
        public async Task<IActionResult> ResetPassword()
        {
            await userService.ResetPassword();
            return Ok();
        }

        [HttpPut("changepassword/{newPassword}"), Authorize]
        [ServiceFilter(typeof(PasswordFilter))]
        public async Task<IActionResult> ChangePassword([FromBody] string confirmPassword, string newPassword)
        {
            User userObject = (User)HttpContext.Items["userObject"];
            await userService.ChangePassword(newPassword, userObject);
            return Ok();
        }

        [HttpPut("changeemail"), Authorize]
        [ServiceFilter(typeof(PasswordFilter))]
        public async Task<IActionResult> ChangeEmail(string confirmPassword, string newEmail)
        {
            User userObject = (User)HttpContext.Items["userObject"];
            await userService.ChangeEmail(newEmail, userObject);
            return Ok();
        }

        [HttpDelete("delete"), Authorize]
        [ServiceFilter(typeof(PasswordFilter))]
        public async Task<IActionResult> DeleteUser([FromBody] string confirmPassword)
        {
            User userObject = (User)HttpContext.Items["userObject"];
            await userService.DeleteUser(userObject);
            return Ok();
        }
    }
}