using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Services.ProfileService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService profileService;
        public ProfileController(IProfileService profileService)
        {
            this.profileService = profileService ?? throw new ArgumentNullException(nameof(profileService));
        }
        private int GetCurrentUserID()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var userID = claims.Where(p => p.Type == "ID").FirstOrDefault()?.Value;
            return Int32.Parse(userID);
        }

        [HttpGet("{id}"), Authorize]
        public IActionResult GetProfile(int id)
        {
            var profile = profileService.Get(id);
            return Ok(profile);
        }

        [HttpPut("put"), Authorize]
        public IActionResult UpdateProfile([FromBody] Profile profile)
        {
            profileService.Update(profile, GetCurrentUserID());
            return Ok();
        }
    }
}
