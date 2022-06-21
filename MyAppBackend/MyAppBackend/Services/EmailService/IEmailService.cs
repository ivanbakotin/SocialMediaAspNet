using MyAppBackend.Models;
using System.Threading.Tasks;

namespace MyAppBackend.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(ResetEmail resetEmail);
    }
}
