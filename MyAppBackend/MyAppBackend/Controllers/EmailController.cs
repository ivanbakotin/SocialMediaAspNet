using Microsoft.AspNetCore.Mvc;
using MyAppBackend.Models;
using MyAppBackend.Data;
using System.Threading.Tasks;
using MyAppBackend.Services.Email;
using System;

namespace MyAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly DataContext context;

        private readonly IEmailService emailService;

        public EmailController(DataContext context, IEmailService emailService)
        {
            this.context = context;
            this.emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        [HttpPost("sendemail")]
        public async Task<IActionResult> Send([FromBody] ResetEmail resetEmail)
        {
            await emailService.SendEmailAsync(resetEmail, context);
            return Ok();
        }

        [HttpPost("resetpassword")]
        public IActionResult ResetPassword([FromBody] User user)
        {
            // check code and user id
            // change password
            return Ok();
        }
    }
}
