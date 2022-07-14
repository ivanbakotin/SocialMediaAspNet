using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.ActionFilters;
using MyAppBackend.ApiModels;
using MyAppBackend.Models;
using MyAppBackend.Services.UserService;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }

        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var result = await userService.GetCurrentUser(GetCurrentUserID());
            return Ok(result);
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

        [HttpPut("resetpassword")]
        public IActionResult ResetPassword()
        {
            userService.ResetPassword();
            return Ok();
        }

        [HttpPut("changepassword")]
        [ServiceFilter(typeof(ModelValidationFilter))]
        [ServiceFilter(typeof(PasswordFilter))]
        public IActionResult ChangePassword([FromBody] UserChange user)
        {
            User userObject = (User)HttpContext.Items["userObject"];
            userService.ChangePassword(user.ChangeField, userObject);
            return Ok();
        }

        [HttpPut("changeemail")]
        [ServiceFilter(typeof(ModelValidationFilter))]
        [ServiceFilter(typeof(PasswordFilter))]
        public IActionResult ChangeEmail([FromBody] UserChange user)
        {
            User userObject = (User)HttpContext.Items["userObject"];
            userService.ChangeEmail(user.ChangeField, userObject);
            return Ok();
        }

        [HttpDelete("delete")]
        [ServiceFilter(typeof(ModelValidationFilter))]
        [ServiceFilter(typeof(PasswordFilter))]
        public IActionResult DeleteUser([FromBody] UserChange user)
        {
            User userObject = (User)HttpContext.Items["userObject"];
            userService.DeleteUser(userObject);
            return Ok();
        }
    }
}