using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using System.Threading.Tasks;
using MyAppBackend.Services.Email;
using System;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : BaseController
    {
        private readonly IEmailService emailService;

        public EmailController(IEmailService emailService)
        {
            this.emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        [HttpPost("passwordreset")]
        public async Task<IActionResult> Send([FromBody] ResetEmail resetEmail)
        {
            await emailService.SendEmailAsync(resetEmail);
            return Ok();
        }
    }
}
