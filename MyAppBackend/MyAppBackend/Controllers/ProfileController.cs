using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Services.ProfileService;
using MyAppBackend.ViewModels;
using System;
using System.Threading.Tasks;

namespace MyAppBackend.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : BaseController
    {
        private readonly IProfileService profileService;

        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetProfile(string username)
        {
            ProfileViewModel profile = await profileService.Get(username, GetCurrentUserID());
            return Ok(profile);
        }

        [HttpPut]
        public IActionResult UpdateProfile([FromBody] Profile profile)
        {
            profileService.Update(profile);
            return Ok();
        }
    }
}