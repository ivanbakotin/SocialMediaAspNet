using MyAppBackend.Data;
using MyAppBackend.Models;
using System.Threading.Tasks;

namespace MyAppBackend.Services.Email
{
    public interface IEmailService
    {
        Task SendEmailAsync(ResetEmail resetEmail, DataContext context);
    }
}
