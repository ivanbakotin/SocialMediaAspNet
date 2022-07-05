using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Services.ProfileService;
using MyAppBackend.ViewModels;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseController
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
        }

        [HttpGet("{username}"), Authorize]
        public async Task<IActionResult> GetProfile(string username)
        {
            ProfileViewModel profile = await profileService.Get(username, GetCurrentUserID());
            return Ok(profile);
        }

        [HttpPut(), Authorize]
        public async Task<IActionResult> UpdateProfile([FromBody] Profile profile)
        {
            await profileService.Update(profile, GetCurrentUserID());
            return Ok();
        }
    }
}